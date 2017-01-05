using UnityEngine;
using System.Collections;


public class Rotate : MonoBehaviour {

	public PlayerController player;
	public Rigidbody2D bridge;
	public GameObject g1;
	public GameObject g2;
	public AudioClip bridgeSound;
	public AudioClip bridgeClunk;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
			Rotation ();
	}

	void Rotation () {

		if(bridge.velocity.y < 0){
			g1.transform.Rotate (Vector3.forward * 5);
			g2.transform.Rotate (Vector3.forward * -5);
		}
	}
}
