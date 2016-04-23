using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour {

    public Text lapCount;
    public PlayerCollisions playerCol;

	// Use this for initialization
	void Start () {
        playerCol = GameObject.Find("Player").GetComponent<PlayerCollisions>();
	}
	
	// Update is called once per frame
	void Update () {
        lapCount.text = ("Lap: " + playerCol.LapNumber);
	}
}
