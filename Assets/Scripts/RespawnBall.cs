using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnBall : MonoBehaviour {

	public Rigidbody2D ball;
	private PlayerController player;
	private LevelManager level;
	public bool set;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		ball.gravityScale = 0f;
		level = FindObjectOfType<LevelManager> ();
		set = false;
	}

	// Update is called once per frame
	void Update () {
		if(player.hasInteracted) {
			if(ball.gravityScale > 0f) {
				level.RespawnzBall ();
				ball.gravityScale = 0f;
			} else {
				ball.gravityScale = 1f;
				player.hasInteracted = false;
			}
		}
		else if(ball.transform.localPosition == level.ballRespawn.transform.localPosition) {
			ball.gravityScale = 0f;
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.name == "Ball Check") {
			set = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.name == "Ball Check") {
			Destroy (c);
		}
	}
}
