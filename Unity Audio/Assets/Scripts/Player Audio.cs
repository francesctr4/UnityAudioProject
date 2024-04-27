using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixerSnapshot outdoor;
    public AudioMixerSnapshot indoor;
    public float transitionDuracion = 1.0f;

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
        if(location == "Indoor")
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
        // Inicia la transición hacia el Snapshot2
        indoor.TransitionTo(transitionDuracion);

        // Espera la duración de la transición
        yield return new WaitForSeconds(transitionDuracion);

        // Restaura el AudioMixer al Snapshot1
        outdoor.TransitionTo(0f);
    }

    IEnumerator TransitiontoOutdoor()
    {
        // Inicia la transición hacia el Snapshot2
        outdoor.TransitionTo(transitionDuracion);

        // Espera la duración de la transición
        yield return new WaitForSeconds(transitionDuracion);

        // Restaura el AudioMixer al Snapshot1
        indoor.TransitionTo(0f);
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
            StartTransicion(other.tag);
            Debug.Log("Outdoor");
        }
    }
}
