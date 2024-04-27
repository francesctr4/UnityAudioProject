using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixerGroup ambientMixer;
    public AudioMixerGroup ambientIndoorMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("No se ha asignado un AudioSource.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Indoor")
        {
            //Cambiar el mixer
            audioSource.outputAudioMixerGroup = ambientIndoorMixer;
            Debug.Log("Indoor");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Indoor")
        {
            //Cambiar el mixer
            audioSource.outputAudioMixerGroup = ambientMixer;
            Debug.Log("Outdoor");
        }
    }
}
