using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private Rigidbody2D rBody;

    public float MaxHealth;
    private float HealthPoints;
    public int GivenScore;
    public float MovementSpeed;
    public ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        HealthPoints = MaxHealth;
        LevelController.EnemyCounter++;
        LevelController.EnemiesOnScreen++;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();

        if (HealthPoints <= 0)
        {
            LevelController.EnemiesOnScreen--;
            ScoreController.Score += GivenScore;
            Camera.main.GetComponent<PowerUpsGenerator>().GeneratePowerUp(transform);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (transform.position.magnitude > 2.0f)
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

    public void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 0.001f * MovementSpeed ;
        transform.position = position;
    }

    public void MoveRight()
    {
        Vector2 position = transform.position;
        position.x += 0.001f;
        transform.position = position;
    }

    public void MoveLeft()
    {
        Vector2 position = transform.position;
        position.x -= 0.001f;
        transform.position = position;
    }

}
