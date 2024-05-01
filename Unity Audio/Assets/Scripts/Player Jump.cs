using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public GroundDetector detector;
    public PlayerFootsteps player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && detector.grounded && player.currentState != PlayerFootsteps.PlayerState.IDLE) 
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
