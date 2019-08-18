using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MaxHealthPoints;
    private float healthPoints;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void GetDamage(float damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
