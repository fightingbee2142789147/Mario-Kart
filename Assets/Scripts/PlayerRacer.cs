using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerRacer : MonoBehaviour {


    public GameObject waypointContainer;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    Vector3 currentWaypointPos;
   

    // Use this for initialization
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

    // Update is called once per frame

    void GetWaypoints()
    {
        // Now, this function basically takes the container object for the waypoints, then finds all of the transforms in it,
        // once it has the transforms, it checks to make sure it's not the container, and adds them to the array of waypoints.
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

