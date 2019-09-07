using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoEnemyMovement : MonoBehaviour
{
    private float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = GetComponent<EnemyController>().MovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }

    public void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 0.001f * MovementSpeed;
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
