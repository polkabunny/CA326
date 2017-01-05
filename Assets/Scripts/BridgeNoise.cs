using UnityEngine;
using System.Collections;

public class BridgeNoise : MonoBehaviour {

	public AudioClip bridgeScreech;
	public PlayerController player;
	public Rigidbody2D bridge;
	private int i;

	// Use this for initialization
	void Start () {
		i = 1;
	}
	
	// Update is called once per frame
	// Play sound while bridge is moving
	void Update () {
		AudioSource audio = GetComponent<AudioSource> ();
		if (bridge.velocity.y != 0) {
			while (i > 0) {
				audio.clip = bridgeScreech;
				audio.Play ();
				i--;
			}
		}
	}
}
