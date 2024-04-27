using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class FootstepsAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] metalFootsteps;
    public AudioClip[] concreteFootsteps;

    private int rngfootsep;

    void Start()
    {
        rngfootsep = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untagged")
        {
            //Audio de asfalto
            audioSource.Play();
        }

        if (other.tag == "Metal")
        {
            //Audio de metal
            audioSource.Play();
        }
    }
}
