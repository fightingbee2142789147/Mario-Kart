using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public GameObject Goal;
    public int LapNumber = 0;
    public AudioSource[] lapAudio;
    public AudioSource music;

	// Use this for initialization
	void Start () {
        lapAudio = GameObject.Find("Line").GetComponents<AudioSource>();
        music = GameObject.Find("MusicMachine").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Finish")
        {
            LapNumber++;
            if (LapNumber <= 2)
            {
                lapAudio[0].Play();
            } else if (LapNumber == 3)
            {
                lapAudio[1].Play();
            }
            else if (LapNumber > 3)
            {
                lapAudio[2].Play();
                music.Stop();
            }

        }
    }
}
