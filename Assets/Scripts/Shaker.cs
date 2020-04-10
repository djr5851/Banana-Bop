using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public AudioClip shaker_sound;
    private float audio_volume = 1.0f;
    public float magnitude_threshold = 1.0f;

    private Rigidbody rb;
    private Vector3 velocity;
    private Transform tf;
    private Vector3 last_position;

    private AudioSource audioSource;

    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource = SVUtilities.SetOrAddAudioSource(gameObject);

        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        isMoving = false;

        last_position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 new_velocity = rb.velocity;
        Vector3 direction_changed = velocity - new_velocity;
        if (direction_changed.magnitude > magnitude_threshold)
        {
            Debug.Log("magnitude = " + direction_changed.magnitude);
            audioSource.volume = direction_changed.magnitude * 0.8f;
            audioSource.Play();
            velocity.x = new_velocity.x;
            velocity.y = new_velocity.y;
            velocity.z = new_velocity.z;
        }

        //Debug.Log("Last position: " + last_position + " current position = " + transform.position);
        //if (!transform.position.Equals(last_position))
        //{
        //    audioSource.Play();
        //    Debug.Log("play shaker sound.");
        //    last_position.x = transform.position.x;
        //    last_position.y = transform.position.y;
        //    last_position.z = transform.position.z;
        //}



    }
}
