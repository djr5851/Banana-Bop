using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToCredits : MonoBehaviour
{
    private Color alphaColor;
    public GameObject blackScreen;
    public GameObject stuffInScene;
    public GameObject sunlight;
    public GameObject credits;
    public GameObject xylophone;
    private float timer = 0.0f;
    private float alpha = 0.0f;
    private bool fading = false;
    private bool counting = false;
    // Start is called before the first frame update
    void Start()
    {
        alphaColor = blackScreen.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = alpha;
        blackScreen.GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G)) Fade();
        if (counting) timer += Time.deltaTime;
        if (fading)
        {
            alpha += 0.003f;
            if (alpha > 1.0f) fading = false;
            alphaColor.a = alpha;
            blackScreen.GetComponent<MeshRenderer>().material.color = alphaColor;
        }
        if (timer >= 5.0f)
        {
            xylophone.SetActive(false);
            RenderSettings.ambientIntensity = 1.0f;
            sunlight.GetComponent<Light>().intensity = 1.0f;
            stuffInScene.SetActive(false);
            alpha -= 0.003f;
            if (alpha < 0.0f) alpha = 0.0f;
            alphaColor.a = alpha;
            blackScreen.GetComponent<MeshRenderer>().material.color = alphaColor;
            credits.transform.Translate(0f, 0.0015f, 0f);
        }
    }

    public void Fade()
    {
        fading = true;
        counting = true;
    }
}
