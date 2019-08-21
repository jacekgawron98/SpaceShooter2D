using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Bullet;
    private Rigidbody2D rBody;

    public float MaxHealth;
    private float HealthPoints;
    public float TouchDamage;
    private float reloadTimeRemaining;
    public float MaxReloadTime;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        HealthPoints = MaxHealth;
        reloadTimeRemaining = 0;
        TouchDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y -= 0.001f;
        transform.position = position;
        Shoot();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bulletCollision = collision.gameObject.GetComponent<Bullet>();

        if (bulletCollision != null)
        {
            GetDamage(bulletCollision.BulletPower);
            Debug.Log("Enemy health: " + HealthPoints + "/" + MaxHealth);
            Destroy(bulletCollision.gameObject);
        }
    }

    void GetDamage(float damage)
    {
        HealthPoints -= damage;
        if(HealthPoints <= 0)
        {
            ScoreController.Score++;
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if(reloadTimeRemaining <= 0 )
        {
            GameObject bulletObject = Instantiate(Bullet, transform.position, Quaternion.identity);
            Bullet bulletController = bulletObject.GetComponent<Bullet>();

            bulletController.Shoot(new Vector2(0,-1));

            reloadTimeRemaining = MaxReloadTime;
        }
        if(reloadTimeRemaining > 0)
        {
            reloadTimeRemaining -= Time.deltaTime;
        }

    }

}
