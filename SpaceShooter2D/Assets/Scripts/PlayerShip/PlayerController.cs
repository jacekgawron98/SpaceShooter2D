using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MaxHealthPoints;
    private float healthPoints;
    public int Score;
    public static float HealthPoints;
    public static bool IsAlive; 
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        Score = 0;
        MaxHealthPoints = 100;
        healthPoints = MaxHealthPoints;
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
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                GetDamage(enemy.TouchDamage);
            }
        }
    }

    private void GetDamage(float damage)
    {
        healthPoints -= damage;
        HealthPoints = healthPoints;
        if (healthPoints <= 0)
        {
            IsAlive = false;
            gameObject.SetActive(false);
        }
    }
}
