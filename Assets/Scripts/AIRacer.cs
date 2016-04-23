using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AIRacer : MonoBehaviour
{

    public GameObject waypointContainer;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    private float inputSteer = 0.0f;
    private float inputTorque = 0.0f;
    public Rigidbody rb;
    Vector3 currentWaypointPos;
    public float speed = 0.1f;
    public NavMeshAgent navmesh;
    public int LapNumber = 0;
    public Countdown count;

    // Use this for initialization
    void Start()
    {
        GetWaypoints();
        rb = GetComponent<Rigidbody>();
        currentWaypointPos = waypoints[currentWaypoint].position;
        navmesh = GetComponent<NavMeshAgent>();
        count = GameObject.Find("CutsceneManager").GetComponent<Countdown>();
    }
    void Update()
    {
        if (count.canStart == true)
        {
            navmesh.speed = 3.5f;
            NavigateTowardsWaypoint();
            if (speed >= 25)
            {
                speed = 25;
            }
            else if (speed < 0)
            {
                speed = 0;
            }
            if (currentWaypoint == waypoints.Count)
            {
                currentWaypoint = 0;
                navmesh.SetDestination(waypoints[0].position);
                currentWaypointPos = new Vector3(waypoints[0].position.x + Random.Range(-5, 5), waypoints[0].position.y, waypoints[0].position.z + Random.Range(-5, 5));

            }
        }
        else
        {
            //navmesh.SetDestination(transform.position);
            navmesh.speed = 0;
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
    void NavigateTowardsWaypoint()
    {
        speed += Time.deltaTime * 5;
        // now we just find the relative position of the waypoint from the car transform,
        // that way we can determine how far to the left and right the waypoint is.
        //waypoints[currentWaypoint].transform.position;
        //transform.LookAt(new Vector3(currentWaypointPos.x + Random.Range(-5, 5), currentWaypointPos.y, currentWaypointPos.z + Random.Range(-5, 5)));
        navmesh.SetDestination(currentWaypointPos);
        transform.position += transform.forward * speed * Time.deltaTime;


    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("Waypoint"))
        {
            
            currentWaypoint++;
            
           
            NavigateTowardsWaypoint();
            currentWaypointPos = new Vector3(waypoints[currentWaypoint].position.x + Random.Range(-5, 5), waypoints[currentWaypoint].position.y, waypoints[currentWaypoint].position.z + Random.Range(-5, 5));

        }
        if (col.gameObject.tag == "Finish")
        {
            LapNumber++;
        }
    }
}
