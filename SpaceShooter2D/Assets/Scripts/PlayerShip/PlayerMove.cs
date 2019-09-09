using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rBody;
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 5;
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
                position.z = 0;
                transform.position = Vector2.MoveTowards(transform.position,position,MovementSpeed * Time.deltaTime);
            }
        }
    }
}
