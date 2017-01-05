using UnityEngine;
using System.Collections;

public class RotatePipe : MonoBehaviour {

	public GameObject pipe;
	public GameObject button;
	private PlayerController player;
	private bool playerInArea;

	// Use this for initialization
	void Start () {
		playerInArea = false;
	}

	void Update() {
		RotatePipes ();
	}

	void RotatePipes() {
		if (playerInArea) {
			if (Input.GetKeyDown (KeyCode.E)) {
				pipe.transform.Rotate (Vector3.forward * 90);
				//player.hasInteracted = false;
			}
		}
	}

	bool OnTriggerEnter2D (Collider2D c) {
		if (c.name == "Player") {
			return playerInArea = true;
		} else
			return false;
	}
	bool OnTriggerExit2D(Collider2D c) {
		if (c.name == "Player") {
			return playerInArea = false;
		} else
			return false;
	}
}
