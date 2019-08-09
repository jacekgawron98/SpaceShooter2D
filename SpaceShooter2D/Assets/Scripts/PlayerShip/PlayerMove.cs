using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 shipPosition = rBody.position;
        Vector2 move = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        shipPosition.x = move.x;

        rBody.MovePosition(shipPosition);    
    }
}
