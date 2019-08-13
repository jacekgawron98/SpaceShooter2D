using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody;
    public float force;
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        force = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed bullet");
        }
            
    }

    public void Shoot()
    {
        Vector2 direction = new Vector2(0, 1);
        rBody.AddForce(direction * force);
    }
}
