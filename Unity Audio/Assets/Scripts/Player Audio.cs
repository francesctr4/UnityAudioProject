using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixerSnapshot outdoor;
    public AudioMixerSnapshot indoor;
    public float transitionDuration = 0.0002f;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null || outdoor == null || indoor == null)
        {
            Debug.LogError("No AudioSource or Snapshot asigned.");
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTransicion(string location)
    {
        if (location == "Indoor")
        {
            StartCoroutine(TransitiontoIndoor());
        }
        else
        {
            StartCoroutine(TransitiontoOutdoor());
        }
        
    }

    IEnumerator TransitiontoIndoor()
    {
        // Inicia la transici�n hacia el Snapshot2
        indoor.TransitionTo(transitionDuration);

        // Espera la duraci�n de la transici�n
        yield return new WaitForSeconds(transitionDuration);
    }

    IEnumerator TransitiontoOutdoor()
    {
        // Inicia la transici�n hacia el Snapshot2
        outdoor.TransitionTo(transitionDuration);

        // Espera la duraci�n de la transici�n
        yield return new WaitForSeconds(transitionDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Indoor")
        {
            //Cambiar el mixer
            StartTransicion(other.tag);
            Debug.Log("Indoor");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Indoor")
        {
            //Cambiar el mixer
            StartTransicion("Outdoor");
            Debug.Log("Outdoor");

        }
    }
}
