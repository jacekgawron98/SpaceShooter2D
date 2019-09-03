using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float MovementSpeed;
    public GameObject Waypoints;
    private List<Transform> waypointsList;
    private int currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        waypointsList = new List<Transform>();
        GetWaypoints();
        MovementSpeed = GetComponent<EnemyController>().MovementSpeed;
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

    void GetWaypoints()
    {
        foreach (Transform child in Waypoints.transform)
        {
            waypointsList.Add(child);
        }
    }
}
