using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private Rigidbody2D rBody;

    public float MaxHealth;
    private float HealthPoints;
    public int GivenScore;
    public ParticleSystem explosionEffect;
    private Vector2 screenBounds;
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        rBody = GetComponent<Rigidbody2D>();
        HealthPoints = MaxHealth;
        LevelController.EnemyCounter++;
        LevelController.EnemiesOnScreen++;
    }

    // Update is called once per frame
    void Update()
    {

        if (HealthPoints <= 0)
        {
            LevelController.EnemiesOnScreen--;
            ScoreController.Score += GivenScore;
            Camera.main.GetComponent<PowerUpsGenerator>().GeneratePowerUp(transform);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (transform.position.y <= -screenBounds.y - 1)
        {
            LevelController.EnemiesOnScreen--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bulletCollision = collision.gameObject.GetComponent<Bullet>();

        if (bulletCollision != null)
        {
            GetDamage(bulletCollision.BulletPower);
            Destroy(bulletCollision.gameObject);
        }
    }

    void GetDamage(float damage)
    {
        HealthPoints -= damage;
    }

}
