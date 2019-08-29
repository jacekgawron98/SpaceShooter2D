using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsGenerator : MonoBehaviour
{
    public GameObject powerUp;


    public void GeneratePowerUp(Transform transform)
    {
        int randomVlue = Random.Range(0, 101);
        if(randomVlue < 50)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("NO POWERUP");
        }
    }
}
