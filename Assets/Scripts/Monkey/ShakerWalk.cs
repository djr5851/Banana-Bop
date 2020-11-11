using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerWalk : MonoBehaviour
{
    public GameObject shaker;
    public Transform destination;
    public GameObject monky;
    private bool moving = true;
    private bool dropped = false;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(0f, 0f, 0.01f);
        }
        if (transform.position.x <= destination.position.x + 1.0f && transform.position.z >= destination.position.z - 1.0f) 
        {
            monky.GetComponent<Animator>().SetTrigger("drop");
            moving = false;
        }
        if (!moving)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3.339998f)
        {
            shaker.transform.parent = null;
            shaker.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
