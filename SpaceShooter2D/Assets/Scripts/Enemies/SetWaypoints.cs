using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaypoints : MonoBehaviour
{
    private List<GameObject> enemies;
    public GameObject MoveWaypoints;
    private List<Transform> waypointsPositions;
    public GameObject FinalWaypoints;
    private List<Transform> finalWaypointsPositions;
    // Start is called before the first frame update
    void Awake()
    {
        enemies = new List<GameObject>();
        waypointsPositions = new List<Transform>();
        finalWaypointsPositions = new List<Transform>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        GetMoveWaypoints();
        GetFinalWaypoints();
        for(int i=0;i<enemies.Count;i++)
        {
            EnemiesMovement movement = enemies[i].GetComponent<EnemiesMovement>();
            //movement.waypointsList = waypointsPositions;
            movement.waypointsList.Add(finalWaypointsPositions[i]);
            enemies[i].GetComponent<EnemiesMovement>().waypointsList = movement.waypointsList;
        }
    }
    
    void GetMoveWaypoints()
    {
        foreach(Transform child in MoveWaypoints.transform)
        {
            waypointsPositions.Add(child);
        }
    }

    void GetFinalWaypoints()
    {
        foreach (Transform child in FinalWaypoints.transform)
        {
            finalWaypointsPositions.Add(child);
        }
    }
}
