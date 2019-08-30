using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBulletPowerUp : MonoBehaviour
{
    public float Duration;

    public void ChangeBullet(GameObject player)
    {
        player.GetComponent<PlayerShooting>().SpecialBulletTimeRemaining = Duration;
        Destroy(gameObject);
    }
}
