﻿using UnityEngine;

/**
 * Control Post Box
 */
public class ControlPostBox : MonoBehaviour {

    /**
     * Audio Switch Light
     */
    public AudioClip audioSwitchLight;

    /**
     * AudioSource Instance
     */
    private AudioSource audioSource;

    /**
     * Delegate Start Machine
     */
    public delegate void StartMachine();

    /**
     * Event On Start Machine
     */ 
    public static event StartMachine OnStartMachine;

    /**
     * Start Method
     */
    void Start () {

        // Get Instances
        audioSource = GetComponent<AudioSource>();
    }

    /**
     * Update Method
     */
    void Update () {
	
	}

    /**
     * On Trigger Enter
     */ 
    void OnTriggerEnter(Collider collider) {

        // Check if Ethan Collision
        if (collider.gameObject.name.Equals("Ethan")) {

            // Execute Audio
            audioSource.PlayOneShot(audioSwitchLight);

            // Check if Event not is null
            if (OnStartMachine != null) {

                OnStartMachine();
            }
        }
    }
}