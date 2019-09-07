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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            Death();
        }
    }

    private void GetDamage(float damage)
    {
        healthPoints -= damage;
        healthPoints = Mathf.Clamp(healthPoints, 0, MaxHealthPoints);
        HealthPoints = healthPoints;
        if (healthPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        IsAlive = false;
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
