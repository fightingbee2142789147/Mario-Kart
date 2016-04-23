using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {


    public AudioSource audio;
    public float speed = 0.1f;
    public float rotateSpeed = 0.1f;
    public float pitchSpeed = 0.0f;
    public float VolumeSpeed;

    // Use this for initialization
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(pitchSpeed > 1.1f)
        {
            pitchSpeed = pitchSpeed - 0.01f;
        } else if(pitchSpeed < 0.5f)
        {
            pitchSpeed = 0.5f;
        }
        if(VolumeSpeed < 0)
        {
            VolumeSpeed = 0;
        } else if (VolumeSpeed > 1)
        {
            VolumeSpeed = 1;
        }
        if (speed >= 25)
        {
            speed = 25;
        }
        else if (speed < 0)
        {
            speed = 0;
        }
        if (rotateSpeed >= 2)
        {
            rotateSpeed = 1;
        }
        else if (rotateSpeed < 0)
        {
            rotateSpeed = 0;
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.X))
        {
            pitchSpeed += Time.deltaTime / 5;
            VolumeSpeed += Time.deltaTime / 2;
            audio.Play();
            audio.pitch = pitchSpeed;
            audio.volume = VolumeSpeed;
            speed += Time.deltaTime * 5;
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            VolumeSpeed -= Time.deltaTime * 1.1f;
            pitchSpeed -= Time.deltaTime * 1.1f;
            audio.pitch = pitchSpeed;
            audio.volume = VolumeSpeed;
            transform.position += transform.forward * speed * Time.deltaTime;
            speed -= Time.deltaTime * 15;
        }
        if (speed > 0)
        {

            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.C))
            {
                rotateSpeed += Time.deltaTime;
                transform.Rotate(Vector3.down * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.C))
            {
                rotateSpeed += Time.deltaTime;
                transform.Rotate(Vector3.up * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C))
            {
                rotateSpeed += Time.deltaTime;
                transform.Rotate(Vector3.down * (rotateSpeed * 1.2f));
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
                {
                    rotateSpeed += Time.deltaTime;
                    transform.Rotate(Vector3.up * (rotateSpeed * 1.2f));
                }
            
            }
        if(speed <= 0)
        {
            audio.Stop();
            audio.volume = 0;
        }

    }
}
        

