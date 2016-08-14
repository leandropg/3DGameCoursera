using UnityEngine;

/**
 * Control Pot
 */
public class ControlPot : MonoBehaviour
{

    /**
     * Audio Falling Pot
     */
    public AudioClip audioFallingPot;

    /**
     * AudioSource Instance
     */
    private AudioSource audioSource;

    /**
     * Start Method
     */
    void Start() {
        // Get Instances
        audioSource = GetComponent<AudioSource>();
    }

    /**
     * Update Method
     */
    void Update() {

    }

    /**
     * On Trigger Enter
     */
    void OnTriggerEnter(Collider collider)
    {

        // Check if Ethan Collision
        if (collider.gameObject.name.Contains("BallPot")) {

            // Execute Audio
            audioSource.PlayOneShot(audioFallingPot);
        }
    }
}