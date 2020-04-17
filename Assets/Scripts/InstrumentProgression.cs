using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentProgression : MonoBehaviour
{
    public GameObject stick;
    public GameObject rock;
    public GameObject mallet;
    public GameObject xylophone;
    public GameObject shaker;
    public GameObject drumset;
    public float timer;
    public float rockStartTime;
    public float xylophoneStartTime;
    public float shakerStartTime;
    public float drumStartTime;

    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rockStartTime)
        {
            stick.SetActive(true);
            rock.SetActive(true);
        }
        if (timer >= xylophoneStartTime)
        {
            mallet.SetActive(true);
            xylophone.SetActive(true);
        }
        if (timer >= shakerStartTime)
        {
            shaker.SetActive(true);
        }
        if (timer >= drumStartTime)
        {
            drumset.SetActive(true);
        }
    }
}
