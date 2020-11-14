using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip chh;
    public GameObject collisionSphere;
    public float velocity;
    private float velPrev;
    private float timer = 0f;
    private bool timing = false;
    private Vector3 posPrev;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velPrev = velocity;
        velocity = ((transform.position - posPrev).magnitude);
        posPrev = transform.position;
        if (Vector3.Distance(transform.position, collisionSphere.transform.position) > 0.08f)
        {
            if (velPrev > 0.01f && velPrev > velocity)
            {
                if (!timing)
                {
                    timing = true;
                    collisionSphere.transform.position = transform.position;
                    collisionSphere.transform.rotation = transform.rotation;
                    sound.PlayOneShot(chh, velocity/0.1f);
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= 0.01f)
                    {
                        timing = false;
                        timer = 0f;
                    }
                }
            }
        }
    }

    void OnTriggerExit()
    {
    }
}
