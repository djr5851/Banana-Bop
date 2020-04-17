using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public bool speedExceeded;
    // Start is called before the first frame update
    void Start()
    {
        speedExceeded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!speedExceeded)
        {
            if (GetComponent<Rigidbody>().velocity.sqrMagnitude > 50)
                speedExceeded = true;
        }
        else
        {
            if (GetComponent<Rigidbody>().velocity.sqrMagnitude <= 1)
            {
                GetComponent<AudioSource>().Play();
                speedExceeded = false;
            }
        }
    }
}
