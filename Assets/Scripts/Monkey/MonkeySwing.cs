﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySwing : MonoBehaviour
{
    public GameObject monkey;
    public GameObject rope;
    public GameObject xylophone;
    public GameObject xylophoneColliders;
    public GameObject leftMallet;
    public GameObject rightMallet;
    private bool hasXylophone = false;
    private bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {
        rope.gameObject.SetActive(true);
        monkey.transform.position = new Vector3(-18.012f, 18.767f, -0.99f);
        hasXylophone = true;
        swinging = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasXylophone) 
        {
            if (xylophone.transform.position.x >= -2.1407f)
            {
                xylophone.transform.parent = null;
                xylophone.transform.position = new Vector3(-2.1407f, 0.9829998f, 0.030527f);
                xylophoneColliders.SetActive(true);
                leftMallet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                rightMallet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
