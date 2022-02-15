using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounceNoise : MonoBehaviour
{

    public AudioClip sound;
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
        if (collision.gameObject.name == "Ball")
        {
            AudioSource clip = GetComponent<AudioSource>();
            clip.clip = sound;
            clip.Play();
        }
    }
}
