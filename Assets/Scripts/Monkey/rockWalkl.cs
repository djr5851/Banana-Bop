using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockWalkl : MonoBehaviour
{
    public GameObject rock;
    public Transform destination;
    public GameObject monky;
    private bool moving = true;
    private bool dropped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(0.01f, 0f, 0f);
        }
        if (transform.position.x >= destination.position.x && transform.position.z >= destination.position.z) 
        {
            monky.GetComponent<Animator>().SetTrigger("drop");
            moving = false;
        }
        if (!moving)
        {
            rock.transform.parent = null;
            rock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
