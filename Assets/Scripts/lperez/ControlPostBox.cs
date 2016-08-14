using UnityEngine;

/**
 * Control Post Box
 */
public class ControlPostBox : MonoBehaviour {

    /**
     * Animator Instance
     */
    private Animator anim;

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
        anim = GetComponent<Animator>();
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
        if (collider.gameObject.name.Contains("Ethan")) {

            // Check if Event not is null
            if(OnStartMachine != null) {

                OnStartMachine();
            }
        }
    }
}