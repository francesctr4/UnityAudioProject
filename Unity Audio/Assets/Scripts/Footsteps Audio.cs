using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    public AudioClip[] metalFootsteps;

    public AudioClip[] concreteFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untagged")
        {
            //Audio de asfalto
        }

        if (other.tag == "Metal")
        {
            //Audio de metal
        }
    }
}
