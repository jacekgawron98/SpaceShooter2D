using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 screenBounds;
    Rigidbody2D rBody;
    public float force;
    public float BulletPower;
    // Start is called before the first frame update
    void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= screenBounds.y)
        {
            Destroy(gameObject);
        }
            
    }

    public void Shoot(Vector2 direction)
    {
        rBody.AddForce(direction * force);
    }
}
