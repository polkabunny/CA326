using UnityEngine;
using System.Collections;

public class LightPanel1 : MonoBehaviour {

	public SpriteRenderer light1;
	public SpriteRenderer light2;
	public SpriteRenderer light3;
	public SpriteRenderer lightoff;
	private SpriteRenderer[] lights;

	private bool playerInArea;
	public bool set;
	public int clicks;

	// Use this for initialization
	void Start() {
		set = false;
		clicks = 0;
		lights = new SpriteRenderer[] { light1, light2, light3, lightoff };
		playerInArea = false;
	}

	//turn off the lights
	void TurnOff() {
		for(int j = 0; j < lights.Length; j++) {
			lights [j].enabled = false;
		}
	}

	// Update is called once per frame
	void Update() {
		if (light2.enabled & !light3.enabled)
			set = true;
		else
			set = false;
		
		if (playerInArea) {
			if (clicks == lights.Length) {
				clicks = 0;
				TurnOff ();
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				lights [clicks].enabled = true;
				clicks++;
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
