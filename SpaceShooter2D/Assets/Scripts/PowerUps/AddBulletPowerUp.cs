using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBulletPowerUp : MonoBehaviour
{
    public void AddBullet(GameObject playerObject)
    {
        PlayerShooting playerShooting = playerObject.GetComponent<PlayerShooting>();
        playerShooting.NumberOfBullets++;
        playerShooting.NumberOfBullets = Mathf.Clamp(playerShooting.NumberOfBullets, 1, 5);
        Destroy(gameObject);
    }
}
