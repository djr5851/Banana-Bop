﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumMonkeyMove : MonoBehaviour
{
    public float speed;
    public GameObject monky;
    public Transform drumsetPos;
    public Transform monkyDancePos;
    private bool monkyClose = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(-speed, 0, 0);
        if (!monkyClose && gameObject.transform.position.x <= monkyDancePos.position.x && gameObject.transform.position.z <= monkyDancePos.position.z)
        {
            monkyClose = true;
            monky.GetComponent<Animator>().SetTrigger("dance");
        }
        if (monkyClose && gameObject.transform.position.x <= drumsetPos.position.x && gameObject.transform.position.z <= drumsetPos.position.z)
        {
            this.enabled = false;
        }
    }
}
