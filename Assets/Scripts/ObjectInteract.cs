using UnityEngine;
using System.Collections;

public class ObjectInteract : MonoBehaviour {

	private PlayerController player;
	private string currentLevel;
	public bool canInteract;

	void Start() {
		player = FindObjectOfType<PlayerController> ();
		canInteract = false;
	}

	void OnTriggerEnter2D (Collider2D c) {
			if (c.name == "Player") {
				player.canInteract = true;
			}
		canInteract = true;
	}

	void OnTriggerExit2D(Collider2D c) {
			if (c.name == "Player") {
				player.canInteract = false;
			}
		canInteract = false;
	}
}
