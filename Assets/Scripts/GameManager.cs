using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState {Start, Playing, End}
    GameState gameState;
    Color fogColor;
    float colorLerp;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogDensity = 1.0f;
        fogColor = new Color(0.673f, 0.925f, 0.659f, 1.000f);
        RenderSettings.fogColor = Color.black;
        gameState = GameState.Start;
        colorLerp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FadeIn()
    {
        while (RenderSettings.fogDensity > 0.05f)
        {
            colorLerp += 0.4f * Time.deltaTime;
            RenderSettings.fogColor = Color.Lerp(Color.black, fogColor, colorLerp);
            RenderSettings.fogDensity -= 0.4f * Time.deltaTime;
            canvas.GetComponent<CanvasGroup>().alpha -= 0.6f * Time.deltaTime;
            yield return null;
        }
    }

    public void StartGame() 
    {
        StartCoroutine(FadeIn());
    }
}
