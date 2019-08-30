using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsGenerator : MonoBehaviour
{
    [System.Serializable]
    public class PowerUp
    {
        public int rarity;
        public GameObject powerUpType;
    }

    public List<PowerUp> PowerUpsList = new List<PowerUp>();

    public int DropChance;
    public void GeneratePowerUp(Transform transform)
    {
        int dropRandom = Random.Range(0, 101);
        if(dropRandom <= DropChance)
        {
            int dropsRarityTotal = 0;
            for(int i=0;i<PowerUpsList.Count;i++)
            {
                dropsRarityTotal += PowerUpsList[i].rarity;
            }

            int itemRandom = Random.Range(0, dropsRarityTotal);
            for(int i=0;i<PowerUpsList.Count;i++)
            {
                if(itemRandom <= PowerUpsList[i].rarity)
                {
                    Instantiate(PowerUpsList[i].powerUpType, transform.position, Quaternion.identity);
                    break;
                }
                dropsRarityTotal -= PowerUpsList[i].rarity;
            }
        }
        else
        {
            Debug.Log("NO POWERUP");
        }
    }
}
