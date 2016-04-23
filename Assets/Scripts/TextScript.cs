using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour {

    public Text lapCount;
    public Text Speed;
    public Text place;
    public Transform person;
    public Transform Ai1;
    public Transform Ai2;
    public PlayerCollisions playerCol;
    public int placement = 1;
    public Controls player;
    public float distanceBetween;
    public AIRacer ai1;
    public AIRacer ai2;
    public PlayerRacer playrace;

    // Use this for initialization
    void Start () {
        playerCol = GameObject.Find("Player").GetComponent<PlayerCollisions>();
        player = GameObject.Find("Player").GetComponent<Controls>();
        ai1 = GameObject.Find("AI1").GetComponent<AIRacer>();
        ai2 = GameObject.Find("AI2").GetComponent<AIRacer>();
        playrace = GameObject.Find("Player").GetComponent<PlayerRacer>();
	}
    void PersonsPlace()
    {
        if (playerCol.LapNumber == ai1.LapNumber && playerCol.LapNumber == ai2.LapNumber)
        {
            if (playrace.currentWaypoint > ai1.currentWaypoint && playrace.currentWaypoint > ai2.currentWaypoint)
            {
                placement = 1;
                place.text = ("" + placement);
            }
            else if (playrace.currentWaypoint < ai1.currentWaypoint && playrace.currentWaypoint > ai2.currentWaypoint)
            {
                placement = 2;
                place.text = ("" + placement);
            }
            else if (playrace.currentWaypoint < ai1.currentWaypoint && playrace.currentWaypoint < ai2.currentWaypoint)
            {
                placement = 3;
                place.text = ("" + placement);
            }
            else if (playrace.currentWaypoint > ai1.currentWaypoint && playrace.currentWaypoint < ai2.currentWaypoint)
            {
                placement = 2;
                place.text = ("" + placement);
            }
            else
            {
                placement = 3;
                place.text = ("" + placement);
            }
        }
        if (playerCol.LapNumber > ai1.LapNumber && playerCol.LapNumber > ai2.LapNumber)
        {
            placement = 1;
            place.text = ("" + placement);
        }
        if (playerCol.LapNumber < ai1.LapNumber && playerCol.LapNumber < ai2.LapNumber)
        {
            placement = 3;
            place.text = ("" + placement);
        }
    }
        // Update is called once per frame
        void Update ()
    {
        PersonsPlace();
        lapCount.text = ("Lap: " + playerCol.LapNumber);
        Speed.text = ("" + Mathf.Round((player.speed * 2.2f)) + " KM/H");
        place.text = ("" + placement);
	}
}
