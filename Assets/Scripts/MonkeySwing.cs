using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySwing : MonoBehaviour
{
    public GameObject monkey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            monkey.transform.Translate(0, 0, 30f);
        } 
    }
}
