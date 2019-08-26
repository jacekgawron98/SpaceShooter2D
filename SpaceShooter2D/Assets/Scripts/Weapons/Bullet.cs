using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody;
    public float force;
    public float BulletPower;
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        force = 100;
        BulletPower = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 2.0f)
        {
            Destroy(gameObject);
        }
            
    }

    public void Shoot(Vector2 direction)
    {
        rBody.AddForce(direction * force);
    }
}
