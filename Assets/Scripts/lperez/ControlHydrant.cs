using UnityEngine;

/**
 * Control Hydrant
 */ 
public class ControlHydrant : MonoBehaviour {

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
        GameObject hydrantWater;
        ParticleSystem particleSystem;

        // Check if Ethan Collision
        if (collider.gameObject.name.Contains("Bus"))
        {
            // Get Hydrant Water
            hydrantWater = GameObject.Find("HydrantWater");

            // Get Particle System
            particleSystem = hydrantWater.GetComponentInChildren<ParticleSystem>();

            // Play Animation
            particleSystem.Play();

            // Check if Event not is null
            if (OnOpenWater != null) {

                OnOpenWater();
            }
        }
    }
}
