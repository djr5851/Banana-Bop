using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySwing : MonoBehaviour
{
    public GameObject monkey;
    public GameObject rope;
    public GameObject xylophone;
    private bool hasXylophone = false;
    private bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            rope.gameObject.SetActive(true);
            monkey.transform.position = new Vector3(-18.012f, 18.767f, -0.99f);
            hasXylophone = true;
            swinging = true;
        } 

        if (hasXylophone) 
        {
            if (xylophone.transform.position.x >= -2.1407f)
            {
                xylophone.transform.parent = null;
                xylophone.transform.position = new Vector3(-2.1407f, 0.9829998f, 0.030527f);
                hasXylophone = false;
            }
        }

        if (swinging)
        {
            if (monkey.transform.position.x >= 11.51617f)
            {
                rope.gameObject.SetActive(false);
                swinging = false;
            }
        }
    }
}
