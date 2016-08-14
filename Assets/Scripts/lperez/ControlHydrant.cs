using UnityEngine;

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

            // Check if Event not is null
            if (OnOpenWater != null) {

                OnOpenWater();
            }
        }
    }
}
