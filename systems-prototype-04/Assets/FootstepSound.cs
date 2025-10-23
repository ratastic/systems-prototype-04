using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootstepSound : MonoBehaviour
{
    private AudioSource walk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            Debug.Log("buttons are being pressed");
            if (!walk.isPlaying) 
            {
                walk.Play();
            }
        }
        else
        {
            if (walk.isPlaying)
            {
                walk.Pause();
            }
        }
    }
}
