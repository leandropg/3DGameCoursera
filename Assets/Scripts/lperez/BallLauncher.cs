using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/**
 * Ball Launcher
 */
public class BallLauncher : MonoBehaviour {

    /**
     * Ball Counter
     */
    public int ballCounter;

    /**
     * Ball Prefab
     */
    public GameObject ballPrefab;

    /**
     * Start Delay
     */
    public float startDelay = 0.0f;

    /**
     * Delay Between Generate
     */
    public float betweenDelay = 10.0f;

    /**
     * Force X
     */
    public float forceX = 0.0f;

    /**
     * Force Y
     */
    public float forceY = 0.0f;

    /**
     * Force Z
     */
    public float forceZ = 0.0f;

    /**
     * Flag Is Started
     */
    private bool isStarted = false;

    /**
     * Audio Launch Ball
     */
    public AudioClip audioLaunchBall;

    /**
     * AudioSource Instance
     */
    private AudioSource audioSource;

    /*
     * Start Method
     */
    void Start () {

        GameObject startLigth;
        Light ligth;

        // Get Instances
        audioSource = GetComponent<AudioSource>();

        // Get Start Light
        startLigth = GameObject.Find("Start Light");
        ligth = startLigth.GetComponentInChildren<Light>();
        ligth.enabled = false;

        // Register Analytics Custom Event
        Analytics.CustomEvent("startMachine", new Dictionary<string, object>
        {
            { "timeStartMachine", Time.time },
            { "ballCounter", ballCounter }
        });

        // Init Counter
        ballCounter = 0;
    }
	
	/**
     * Update Method
     */
	void Update () {
	
	}

    /**
     * On Enable
     */ 
    void OnEnable() {

        ControlPostBox.OnStartMachine += StartStopBallLauncher;
    }

    /**
     * On Disable
     */
    void OnDisable() {

        ControlPostBox.OnStartMachine += StartStopBallLauncher;
    }

    /**
     * Start Ball Launcher
     */
    void StartStopBallLauncher() {

        GameObject startLigth;
        Light ligth;

        // Get Start Light
        startLigth = GameObject.Find("Start Light");
        ligth = startLigth.GetComponentInChildren<Light>();

        // Check Flag Is Started
        if (!isStarted) {

            InvokeRepeating("LaunchBall", startDelay, betweenDelay);
            isStarted = true;
            ligth.enabled = true;

        } else {

            CancelInvoke();
            isStarted = false;
            ligth.enabled = false;
        }
    }

    /**
     * Launch Ball
     */
    void LaunchBall()
    {
        GameObject ball;
        Rigidbody rgb;

        // Instance Ball
        ball = Instantiate(ballPrefab);

        // Put Ball in Initial Position
        ball.transform.position = transform.position;

        // Get Ball Rigid Body
        rgb = ball.GetComponent<Rigidbody>();

        // Apply Force to Ball
        rgb.AddRelativeForce(new Vector3(forceX, forceY, forceZ), ForceMode.Impulse);

        // Execute Audio
        audioSource.PlayOneShot(audioLaunchBall);

        // Increment Counter
        ballCounter++;
    }
}