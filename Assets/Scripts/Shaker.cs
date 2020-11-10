using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float velocity;
    private Vector3 posPrev;
    private Quaternion rotPrev;
    private float velPrev;
    public float acceleration;
    public GameObject controller;
    private short frame = 0;
    private int numFrames = 5;
    public GameObject test;
    private AudioSource sound;
    public List<Vector3> posPrevList;
    public float distance;
    public float highest = 0f;
    public GameObject shakerBox;
    public GameObject shakerBall;
    // Start is called before the first frame update
    void Start()
    {
        // posPrev = transform.position;
        // rotPrev = transform.rotation;
        // sound = GetComponent<AudioSource>();
        // posPrevList = new List<Vector3>();
        // for (int i = 0; i < numFrames; i++)
        // {
        //     posPrevList.Add(new Vector3(0f, 0f, 0f));
        // }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // velocity = ((transform.position - posPrev).magnitude) / Time.deltaTime;
        // posPrev = transform.position;

        // acceleration = (velocity - velPrev) / Time.deltaTime;
        // velPrev = velocity;

        // if (velocity > 1.0f)
        // {
        //     if (GetComponent<AudioSource>().isPlaying == false) 
        //     {
        //         //test.SetActive(true);
        //         GetComponent<AudioSource>().Play();
        //     }
        // }
        // posPrevList[frame] = transform.position;
        // frame++;
        // if (frame == numFrames)
        // {
        //     frame = 0;
        // }
        // distance = (posPrevList[0] - posPrevList[numFrames - 1]).magnitude;
        // if (distance > highest) highest = distance;
        // if (highest > 1.0f) highest = 0f;
        // if (distance >= 1.01f) sound.Play();
        shakerBox.transform.position = transform.position;
        shakerBox.transform.rotation = transform.rotation;
        //shakerBall.transform.position = Vector3.zero;
        // test.transform.rotation = rotPrev;
    }
}
