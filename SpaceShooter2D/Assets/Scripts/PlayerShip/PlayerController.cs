using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MaxHealthPoints;
    private float healthPoints;
    public static float HealthPoints;
    public static bool IsAlive;
    public ParticleSystem explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        MaxHealthPoints = 100;
        healthPoints = MaxHealthPoints;
        HealthPoints = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet enemyBullet = collision.gameObject.GetComponent<Bullet>();
        if(enemyBullet != null)
        {
            GetDamage(enemyBullet.BulletPower);
            Destroy(collision.gameObject);  
        }
        else
        {
            Debug.Log("aaaa");
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                Debug.Log("TOUCHED");
                GetDamage(enemy.TouchDamage);
            }
        }
    }

    private void GetDamage(float damage)
    {
        healthPoints -= damage;
        healthPoints = Mathf.Clamp(healthPoints, 0, MaxHealthPoints);
        HealthPoints = healthPoints;
        if (healthPoints <= 0)
        {
            IsAlive = false;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
