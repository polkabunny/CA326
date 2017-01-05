using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

	public LightPanel1 light1;
	public LightPanel2 light2;
	public LightPanel3 light3;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (light1.set & light2.set & light3.set)
			player.hasInteracted = true;
	}
}
