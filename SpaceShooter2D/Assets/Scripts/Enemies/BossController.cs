using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D rBody;

    public float MaxHealth;
    private float HealthPoints;
    public float TouchDamage;
    public float MovementSpeed;
    public int GivenScore;

    private Vector2 readyPosition;
    private bool isOnPosition;

    public static bool IsAlive;
    public static bool IsCreated;

    public GameObject waypointsObject;
    List<Transform> waypoints = new List<Transform>();
    int currentWaypoint = 0;

    public ParticleSystem explosionEffect;

    //START
    void Start()
    {
        IsCreated = true;
        IsAlive = true;

        isOnPosition = false;

        readyPosition = new Vector2(0,0.7f);
        getWaypoints();
        

        rBody = GetComponent<Rigidbody2D>();
        HealthPoints = MaxHealth;
        LevelController.EnemiesOnScreen++;
        LevelController.EnemyCounter++;    
    }
    //UPDATE
    void Update()
    {
        if (!transform.position.Equals(readyPosition) && !isOnPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, readyPosition, Time.deltaTime * MovementSpeed);
        }
        else if(transform.position.Equals(readyPosition) && !isOnPosition)
        {
            isOnPosition = true;
        }
        else if(isOnPosition)
        {
            moveAround();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        if (HealthPoints <= 0)
        {
            LevelController.EnemiesOnScreen--;
            ScoreController.Score+=GivenScore;
            IsAlive = false;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void getWaypoints()
    {
        foreach (Transform child in waypointsObject.transform)
        {
            waypoints.Add(child);
        }
    }

    private void moveAround()
    {
        
        if(Vector2.Distance(waypoints[currentWaypoint].position,transform.position) < 0.01f)
        {
            currentWaypoint++;
            if(currentWaypoint == waypoints.Count)
            {
                waypoints.Reverse();
                currentWaypoint = 1;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * MovementSpeed);
    }

    public static void ResetStaticValues()
    {
        IsAlive = false;
        IsCreated = false;
    }
}
