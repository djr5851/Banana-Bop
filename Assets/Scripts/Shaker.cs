using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public bool veloityExceeded;
    public float velocity;
    private Vector3 previous;
    // Start is called before the first frame update
    void Start()
    {
        previous = transform.position;
        veloityExceeded = false;

    }

    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;
        if (!veloityExceeded)
        {
            if (velocity > 50)
                veloityExceeded = true;
        }
        else
        {
            if (velocity <= 1)
            {
                GetComponent<AudioSource>().Play();
                veloityExceeded = false;
            }
        }
    }
}
