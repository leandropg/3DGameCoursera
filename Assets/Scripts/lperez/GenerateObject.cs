using UnityEngine;

public class GenerateObject : MonoBehaviour {

    /**
     * Game Object
     */ 
    public GameObject obj;

    /**
     * Start Delay
     */ 
    public float startDelay = 0.0f;

    /**
     * Delay Between Generate
     */ 
    public float betweenDelay = 10.0f;

    // Use this for initialization
    void Start () {

        InvokeRepeating("ObjectGenerator", startDelay, betweenDelay);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Generate Object
     */
    void ObjectGenerator() {

        // Instance Game Object
        Instantiate(obj);

        // Put Object into position
        obj.transform.position = transform.position;
    }
}
