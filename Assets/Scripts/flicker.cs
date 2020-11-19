using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    private Light lite;
    private float sample;
    private float offset = 1.0f;
    private bool dimming = false;

    // Start is called before the first frame update
    void Start()
    {
        sample = Random.Range(0f, 1f);
        lite = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dimming) offset -= 0.005f;
        lite.intensity = Mathf.PerlinNoise(sample, sample) + offset;
        sample += 0.03f;
    }

    public void Stop()
    {
        dimming = true;
    }
}
