using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerBall : MonoBehaviour
{
    public Transform boxCenter;
    public AudioSource sound;
    private bool delayCounting = false;
    private float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position - boxCenter.transform.position).sqrMagnitude >= 0.05f) {
            gameObject.transform.position = boxCenter.transform.position;
        }
        if (delayCounting)
        {
            delay += Time.deltaTime;
            if (delay >= 0.125f)
            {
                delayCounting = false;
                delay = 0.0f;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!delayCounting && other.gameObject.layer == 10)
        {
            sound.PlayOneShot(sound.clip, GetComponent<Rigidbody>().velocity.sqrMagnitude / 5f);
            delayCounting = true;
        }
    }


}
