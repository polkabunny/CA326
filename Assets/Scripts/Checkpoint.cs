using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelMng;

    // Use this for initialization
    void Start() {
        levelMng = FindObjectOfType<LevelManager>();
    }

	// If player enters collider
	// Set currentcheckpoint to that collider
    void OnTriggerEnter2D(Collider2D c) {
        if (c.name == "Player") {
            levelMng.currentCheckpoint = gameObject;
			// Debug for testing
            Debug.Log("Activated Checkpoint " + transform.position);
        }
    }
}
