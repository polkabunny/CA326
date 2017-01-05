using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	void OnTriggerEnter2D (Collider2D c) {
        if (c.name == "Player")
            player.onLadder = true;
	}

    void OnTriggerExit2D(Collider2D c) {
        if (c.name == "Player")
            player.onLadder = false;
    }
}
