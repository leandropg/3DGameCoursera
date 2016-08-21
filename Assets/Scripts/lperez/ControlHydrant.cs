using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/**
 * Control Hydrant
 */
public class ControlHydrant : MonoBehaviour {

    /**
     * Audio Water
     */
    public AudioClip audioWater;

    /**
     * AudioSource Instance
     */
    private AudioSource audioSource;

    /**
     * Delegate Open Water
     */
    public delegate void OpenWater();

    /**
     * Event On Open Water
     */
    public static event OpenWater OnOpenWater;

    /**
     * Start Method
     */
    void Start () {

        GameObject water;
        ParticleSystem particleSystem;

        // Get Instances
        audioSource = GetComponent<AudioSource>();

        // Get Hydrant Water
        water = GameObject.Find("Water");

        // Get Particle System
        particleSystem = water.GetComponent<ParticleSystem>();

        // Stop Animation
        particleSystem.Stop();
    }
	
	/**
     * Update Method
     */ 
	void Update () {
	
	}

    /**
     * On Trigger Enter
     */
    void OnTriggerEnter(Collider collider)
    {
        BallLauncher ballLauncher;
        GameObject water;
        ParticleSystem particleSystem;

        // Check if Ethan Collision
        if (collider.gameObject.name.Contains("Bus"))
        {
            // Get Hydrant Water
            water = GameObject.Find("Water");

            // Get Particle System
            particleSystem = water.GetComponent<ParticleSystem>();

            // Play Animation
            particleSystem.Play();

            // Execute Audio
            audioSource.PlayOneShot(audioWater);

            // Get Ball Launcher Object
            ballLauncher = GameObject.Find("Ball Launcher").GetComponent<BallLauncher>();

            // Register Analytics Custom Event
            Analytics.CustomEvent("stopMachine", new Dictionary<string, object>
            {
                { "timeStopMachine", Time.time },
                { "ballCounter", ballLauncher.ballCounter }
            });

            // Check if Event not is null
            if (OnOpenWater != null) {

                // Open Water
                OnOpenWater();
            }
        }
    }
}
