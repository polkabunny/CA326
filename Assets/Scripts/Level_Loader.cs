using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level_Loader : MonoBehaviour {

	private bool playerInZone;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone) {
			SceneManager.LoadScene(levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = true;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = false;
		}

	}
}
