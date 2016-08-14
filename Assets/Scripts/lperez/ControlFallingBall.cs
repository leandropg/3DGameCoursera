using UnityEngine;

/**
 * Control Falling Ball
 */
public class ControlFallingBall : MonoBehaviour
{

    /**
     * Audio Falling Ball
     */
    public AudioClip audioFallingBall;

    /**
     * AudioSource Instance
     */
    private AudioSource audioSource;

    /**
     * Start Method 
     */
    void Start()
    {

        // Get Instances
        audioSource = GetComponent<AudioSource>();
    }

    /**
     * Update Method
     */
    void Update()
    {

    }

    /**
    * On Trigger Enter
    */
    void OnTriggerEnter(Collider collider)
    {
        // Check if Ethan Collision
        if (collider.gameObject.name.Equals("BowlingBall")) {

            // Execute Audio
            audioSource.PlayOneShot(audioFallingBall);
        }
    }
}