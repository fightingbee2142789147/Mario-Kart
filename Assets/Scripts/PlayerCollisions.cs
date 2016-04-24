using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public GameObject Goal;
    public GameObject player;
    public int LapNumber = 0;
    public AudioSource[] lapAudio;
    public AudioSource music;
    public Rigidbody rb;
    public Controls control;
    public float timerate;
    public int timefac = 2;


    private static int WAYPOINT_VALUE = 100;
    private static int LAP_VALUE = 10000;


    // Use this for initialization
    void Start () {
        lapAudio = GameObject.Find("Line").GetComponents<AudioSource>();
        music = GameObject.Find("MusicMachine").GetComponent<AudioSource>();
        control = GameObject.Find("Player").GetComponent<Controls>();
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

	}
    void OnCollisionEnter(Collision col)
    {
       
        if(col.gameObject.tag == "AI")
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
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
            else if (LapNumber >= 3)
            {
                
                lapAudio[3].Play();
                music.Stop();
                StartCoroutine(endAudio());
                }
            }

        }
    IEnumerator endAudio()
    {
        
        yield return new WaitForSeconds(2);
        lapAudio[3].Stop();
        lapAudio[2].Play();
    }
   
}
