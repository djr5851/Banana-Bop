using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float velocity;
    private Vector3 posPrev;
    private float velPrev;
    public float acceleration;
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        posPrev = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.position - posPrev).magnitude) / Time.deltaTime;
        posPrev = transform.position;

        acceleration = (velocity - velPrev) / Time.deltaTime;
        velPrev = velocity;

        if (velocity > 5.0f)
        {
            test.SetActive(true);
            //if (GetComponent<AudioSource>().isPlaying == false)
                GetComponent<AudioSource>().Play();
        }
        else
        {
            test.SetActive(false);
        }
    }
}
