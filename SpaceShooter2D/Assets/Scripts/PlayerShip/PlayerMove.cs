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
        MovementSpeed = 10;
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector2 shipPosition = rBody.position;
        Vector2 move = new Vector2(horizontalMove,verticalMove);

        shipPosition += MovementSpeed * move * Time.deltaTime;

        rBody.MovePosition(shipPosition);    
    }
}
