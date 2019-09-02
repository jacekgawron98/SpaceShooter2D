using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeWaveMovement : MonoBehaviour
{
    public float MovementSpeed;
    public GameObject Waypoints;
    private List<Transform> waypointsList;
    private int currentWaypoint;
    // Start is called before the first frame update
    void Awake()
    {
        currentWaypoint = 0;
        GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnWayPoints();
    }

    public void MoveOnWayPoints()
    {
        if (currentWaypoint < waypointsList.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointsList[currentWaypoint].transform.position, Time.deltaTime * MovementSpeed);
            if (Vector2.Distance(waypointsList[currentWaypoint].transform.position, transform.position) < 0.01f)
            {
                currentWaypoint++;
            }
        }

    }

    private void GetWaypoints()
    {
        waypointsList = new List<Transform>();
        foreach(Transform child in Waypoints.transform)
        {
            waypointsList.Add(child);
        }
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

