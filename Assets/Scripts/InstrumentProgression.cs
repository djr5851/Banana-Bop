using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentProgression : MonoBehaviour
{
    public GameObject rock;
    public GameObject drum;
    public GameObject shaker;
    public GameObject drumset;
    public float timer;
    public float rockStartTime;
    public float drumStartTime;
    public float shakerStartTime;
    public float drumSetStartTime;
    public float xylophoneStartTime;
    public float songStartTime;

    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= songStartTime && timer <= songStartTime + 2)
        {
            // GetComponent<AudioSource>().Play();
        }
        if (timer >= rockStartTime)
        {
            rock.SetActive(true);
        }
        if (timer >= drumStartTime)
        {
            drum.SetActive(true);
        }
        if (timer >= shakerStartTime)
        {
            shaker.SetActive(true);
        }
        if (timer >= drumSetStartTime)
        {
            drumset.SetActive(true);
        }
        if (timer >= xylophoneStartTime)
        {
            GetComponent<MonkeySwing>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            timer = 99999999f;
        }
    }
}
