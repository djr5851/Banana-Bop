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
    //private SVGrabbable grabbable;
    private SVControllerInput input;
    private AudioSource audioSource;


    private void OnTriggerStay(){

		if (Input.GetKey (KeyCode.E)) {
             
			audioSource = SVUtilities.SetOrAddAudioSource(gameObject);
			audioSource.clip = soundOnHit;


			//audioSource.pitch = Random.Range(minPitch, maxPitch);
			audioSource.volume = volume;
			audioSource.Play();
				
		}
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource = SVUtilities.SetOrAddAudioSource(gameObject);
        audioSource.clip = soundOnHit;


        //audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.volume = volume;
        audioSource.Play();
    }
}
