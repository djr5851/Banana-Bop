using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{

    public AudioClip soundOnHit;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    public float volume = 1f;

    private bool inHand = false;
    private SVGrabbable grabbable;
    private SVControllerInput input;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log(rb.velocity.sqrMagnitude);

            if (soundOnHit && collision.gameObject.GetComponent<SVGrabHaptics>().inHand)
            {
                if (audioSource == null)
                {
                    audioSource = SVUtilities.SetOrAddAudioSource(gameObject);
                    audioSource.clip = soundOnHit;
                }

                //audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.volume = volume;
                audioSource.Play();
            }
        }

    }
}
