using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoudspeakerRandomizer : MonoBehaviour
{
    public AudioClip[] loudspeakerClips;
    private AudioSource audioSource;

    public float timeBetweenPlays = 10f;
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
            int randomIndex = Random.Range(0, loudspeakerClips.Length);
            audioSource.PlayOneShot(loudspeakerClips[randomIndex]);
            timer = timeBetweenPlays;
        }
    }
}
