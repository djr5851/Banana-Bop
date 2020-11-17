using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splosion : MonoBehaviour
{
    public GameObject noahSplosion;
    public GameObject noah;
    public GameObject conorSplosion;
    public GameObject conor;
    public GameObject mikeySplosion;
    public GameObject mikey;
    public GameObject michaelSplosion;
    public GameObject michael;
    private bool counting = false;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counting) timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F))
        {
            noahSplosion.SetActive(true);
            conorSplosion.SetActive(true);
            mikeySplosion.SetActive(true);
            michaelSplosion.SetActive(true);
            counting = true;
        }
        if (timer >= 1.0f)
        {
            noah.SetActive(true);
            conor.SetActive(true);
            mikey.SetActive(true);
            michael.SetActive(true);
        }
        if (timer >= 3.0f)
        {
            noahSplosion.GetComponent<ParticleSystem>().Stop();
            conorSplosion.GetComponent<ParticleSystem>().Stop();
            mikeySplosion.GetComponent<ParticleSystem>().Stop();
            michaelSplosion.GetComponent<ParticleSystem>().Stop();
        }
    }
}
