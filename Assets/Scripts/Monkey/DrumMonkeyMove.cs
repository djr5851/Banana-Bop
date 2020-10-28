using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumMonkeyMove : MonoBehaviour
{
    public float speed;
    public GameObject monky;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(-speed, 0, 0);
        if(gameObject.transform.position.x <= 0.86f && gameObject.transform.position.z <= 2.91f)
        {
            monky.GetComponent<Animator>().SetTrigger("dance");
            this.enabled = false;
        }
    }
}
