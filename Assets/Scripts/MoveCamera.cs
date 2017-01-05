using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	private FollowCamera cam;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<FollowCamera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.name == "Player")
			cam.puzzle = true;
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.name == "Player")
			cam.puzzle = false;
	}
}
