using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera vrCam;
    public Camera mouseCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            vrCam.enabled = !vrCam.enabled;
            mouseCam.enabled = !mouseCam.enabled;
        }
    }
}
