using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumWalk : MonoBehaviour
{
    public Transform leftHand;
    public Transform hips;
    public float xOffset;
    public float zOffset;
    private Vector3 drumPos;
    public GameObject drum;
    public Transform destination;
    public Transform dancePos;
    public GameObject monky;
    private bool moving = true;
    private bool dropped = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dropped)
        {
            drum.transform.position = drumPos;
            drum.transform.rotation = hips.rotation;
        }
        if (moving)
        {
            drumPos = leftHand.position;
            drumPos.x += xOffset;
            drumPos.z += zOffset;
            transform.Translate(0.01f, 0f, 0.01f);
        }
        if (transform.position.x <= destination.position.x + 1.0f && transform.position.z >= destination.position.z - 1.0f) 
        {
            monky.GetComponent<Animator>().SetTrigger("drop");
        }
        if (transform.position.x <= destination.position.x && transform.position.z >= destination.position.z) 
        {
            moving = false;
            timer += Time.deltaTime;
        }
        if (timer >= 0.3f)
        {
            dropped = true;
            drum.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (timer >= 1.0f && timer <= 10.0f)
        {
            monky.transform.Translate(-0.002f, 0f, -0.002f);
        }
    }
}
