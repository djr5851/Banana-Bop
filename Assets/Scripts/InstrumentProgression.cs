using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentProgression : MonoBehaviour
{
    public bool counting = false;
    public bool scaling = false;
    public GameObject title;
    public GameObject rock;
    public GameObject drum;
    public GameObject shaker;
    public GameObject drumset;
    private float rate = 0.05f;
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
        if (scaling)
        {
            rate += 0.01f;
            title.transform.Translate(0.0f, 0.005f, 0.0f);
            title.transform.localScale = Vector3.Lerp(title.transform.localScale, Vector3.zero, rate * Time.deltaTime);
            if (title.transform.localScale.x <= 0.001f) scaling = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGame();
        }
        if (counting) timer += Time.deltaTime;
        
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

    public void StartGame()
    {
        counting = true;
        scaling = true;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
