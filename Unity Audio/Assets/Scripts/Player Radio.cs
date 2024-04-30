using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadio : MonoBehaviour
{
    public AudioClip radioClip;
    private AudioSource audioSource;

    public float timeBetweenPlays = 40f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = timeBetweenPlays;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            audioSource.PlayOneShot(radioClip);
            timer = timeBetweenPlays;
        }
    }
}
