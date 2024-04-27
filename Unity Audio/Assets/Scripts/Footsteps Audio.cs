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
            rngfootsep = Random.Range(0, concreteFootsteps.Length);
            audioSource.PlayOneShot(concreteFootsteps[rngfootsep]);
        }

        if (other.tag == "Metal")
        {
            //Audio de metal
            Random.Range(0, metalFootsteps.Length);
            audioSource.PlayOneShot(metalFootsteps[rngfootsep]);
        }
    }
}
