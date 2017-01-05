using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelMng;

	// Use this for initialization
	void Start () {
        levelMng = FindObjectOfType<LevelManager>();
	}

	//Respawn player once it walks into a collider
    void OnTriggerEnter2D (Collider2D c) {
        if(c.name == "Player") {
            levelMng.RespawnPlayer();
        }
    }
}
