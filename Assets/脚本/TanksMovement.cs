using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 5;
    public float angularspeed = 8;           //旋转速度8°每秒
    public float number = 1;

    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalPlayer" + number);
        rigidbody.velocity = transform.forward * v * speed;             //刚体水平速度

        float h = Input.GetAxis("HorizontalPlayer" + number);
        rigidbody.angularVelocity = transform.up * h * angularspeed;        //刚体旋转速度

        if(Mathf.Abs(h)>0.1||Mathf.Abs(v)>0.1)
        {
            audio.clip = drivingAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
    }
}
