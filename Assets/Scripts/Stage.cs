using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject sunlight;
    public GameObject instrumentLight;
    public GameObject stageLight1;
    public GameObject stageLight2;
    public GameObject fireLight1;
    public GameObject fireLight2;
    public GameObject fireLight3;
    public GameObject fireLight4;
    public GameObject ps;
    public GameObject stage;
    public GameObject ah;
    public AudioSource bop;
    public AudioSource soundfx;
    public AudioClip fireball;
    public AudioClip fire;
    public AudioClip whoosh;
    private bool counting = false;
    public float timer = 0.0f;
    private float brightness = 1.0f;
    private bool disabling = true;
    private bool firePlayed = false;
    private bool startedFading = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counting)
        {
            timer += Time.deltaTime;
            stageLight1.transform.Rotate(oscillate(timer, 2, 0.07f), 0, 0);
            stageLight2.transform.Rotate(oscillate(timer, 2, -0.07f), 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.F)) StartShow();
        if (counting)
        {
            ps.transform.Translate(0f, 0.01f, 0f);
        }

        if (timer >= 17.0f)
        {
            ah.SetActive(true);
            if (!firePlayed)
            {
                soundfx.PlayOneShot(fireball);
                soundfx.PlayOneShot(fire);
                firePlayed = true;
            }
            fireLight1.SetActive(true);
            fireLight2.SetActive(true);
            fireLight3.SetActive(true);
            fireLight4.SetActive(true);
        }
        if (timer >= 21.0f)
        {
            stage.SetActive(true);
        }
        if (timer >= 22.0f)
        {
            fireLight1.GetComponent<flicker>().Stop();
            fireLight2.GetComponent<flicker>().Stop();
            fireLight3.GetComponent<flicker>().Stop();
            fireLight4.GetComponent<flicker>().Stop();
        }
        if (timer >= 183.0f)
        {
            if (!startedFading)
            {
                GetComponent<FadeToCredits>().Fade();
                startedFading = true;
            }
        }
        
    }

    float oscillate(float time, float speed, float scale)
    {
        return Mathf.Cos(time * speed / Mathf.PI) * scale;
    }

    IEnumerator Fade()
    {
        while (RenderSettings.ambientIntensity > 0.5f)
        {
            brightness -= 0.4f * Time.deltaTime;
            sunlight.GetComponent<Light>().intensity -= 0.4f * Time.deltaTime;
            instrumentLight.GetComponent<Light>().intensity -= 0.4f * Time.deltaTime;
            RenderSettings.ambientIntensity = brightness;
            yield return null;
        }
    }

    public void StartShow() 
    {
        StartCoroutine(Fade());
        soundfx.PlayOneShot(whoosh);
        bop.Play();
        counting = true;
    }
}

