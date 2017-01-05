using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		// Find the particle system
        thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	// Destroy the particle if it's finished playing
	// Do nothing if it's still playing
	void Update () {
	    if(thisParticleSystem.isPlaying) {
            return;
        }
        else {
            Destroy(gameObject);
        }
	}

	// Once it disappears delete it
    void OnBecomeInvisible () {
        Destroy (gameObject);
    }
}
