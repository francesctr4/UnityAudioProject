using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] concreteFootstepClips;
    public AudioClip[] metalFootstepClips;

    bool toggleFootstepClips = false;

    public float walkTiming = 0.35f;
    public float runTiming = 0.2f;

    private float currentTime;

    public GroundDetector groundDetector;

    [HideInInspector]
    public enum PlayerState
    {
        IDLE,
        WALK,
        RUN,
    }

    [HideInInspector]
    public PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        currentState = PlayerState.IDLE;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.WALK || currentState == PlayerState.RUN)
        {
            currentTime -= Time.deltaTime;
        }

        PlayerStateMachine();
        PlayerStateManagement();

        Debug.Log(currentTime.ToString());
    }

    void PlayerStateMachine()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentState = PlayerState.RUN;
            }
            else
            {
                currentState = PlayerState.WALK;
            }
        }
        else
        {
            currentState = PlayerState.IDLE;
        }

    }

    void PlayerStateManagement()
    {
        switch (currentState)
        {
            case PlayerState.IDLE:

                Debug.Log("IDLE");

                break;

            case PlayerState.WALK:

                Debug.Log("WALK");

                if (currentTime <= 0.0f && groundDetector.grounded)
                {
                    PlayFootstepSound();
                    currentTime = walkTiming;
                }

                break;

            case PlayerState.RUN:

                Debug.Log("RUN");

                if (currentTime <= 0.0f && groundDetector.grounded)
                {
                    PlayFootstepSound();
                    currentTime = runTiming;
                }

                break;

        }
    }

    void PlayFootstepSound()
    {
        if (groundDetector.groundType == "Metal")
        {
            audioSource.PlayOneShot(metalFootstepClips[Convert.ToInt32(toggleFootstepClips)]);     
        }
        else
        {
            audioSource.PlayOneShot(concreteFootstepClips[Convert.ToInt32(toggleFootstepClips)]);
        }

        toggleFootstepClips = !toggleFootstepClips;
    }

}
