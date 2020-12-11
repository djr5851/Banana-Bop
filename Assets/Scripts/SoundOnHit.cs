using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{

    public AudioClip soundOnHit;
    public float pitchAdjust = 1f;
    public float gain;
	float nextSoundTime=0; // can't play sounds if before this time

    private bool inHand = false;
    //private SVGrabbable grabbable;
    private SVControllerInput input;
    private AudioSource audioSource;


    private void OnTriggerStay(){

		if (Input.GetKey (KeyCode.Q) && Time.time>=nextSoundTime) {
             
			audioSource = SVUtilities.SetOrAddAudioSource(gameObject);
			audioSource.clip = soundOnHit;


			audioSource.pitch = pitchAdjust;
			audioSource.volume = gain;
			audioSource.Play();
			
			// write down when we will be finished:
			nextSoundTime = Time.time + .01f;
			//Debug.Log(soundOnHit.length);
				
		}
    }

    private void OnCollisionEnter(Collision collision)
    {
		 // can't play if last one not finished:
		if(Time.time>=nextSoundTime) {
			audioSource = SVUtilities.SetOrAddAudioSource(gameObject);
			audioSource.clip = soundOnHit;

            audioSource.pitch = pitchAdjust;
			float volume = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude / 3f + gain;
			if (volume > 1f) volume = 1f;
            audioSource.volume = volume;
			audioSource.Play();
			
			// write down when we will be finished:
			nextSoundTime = Time.time + .15f;
			//Debug.Log(soundOnHit.length);
		}
    }
}
