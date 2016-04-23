using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerRacer : MonoBehaviour {


    public GameObject waypointContainer;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    Vector3 currentWaypointPos;
   

    void Start()
    {
        GetWaypoints();
        currentWaypointPos = waypoints[currentWaypoint].position;
    }
    void Update()
    {
        if (currentWaypoint == waypoints.Count)
        {
            currentWaypoint = 0;
        }
    }
    void GetWaypoints()
    {
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();
        waypoints = new List<Transform>();

        foreach (Transform potentialWaypoint in potentialWaypoints)
        {
            if (potentialWaypoint != waypointContainer.transform)
            {
                waypoints.Add(potentialWaypoint);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("Waypoint"))
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Count)
            {
                currentWaypoint = 0;
            }
        }
        }
    }

