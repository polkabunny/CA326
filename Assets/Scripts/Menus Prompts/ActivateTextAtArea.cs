using UnityEngine;
using System.Collections;

public class ActivateTextAtArea : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public PromptManager mngr;

	public bool destroyPromptArea;

	// Use this for initialization
	void Start () {
		mngr = FindObjectOfType<PromptManager> ();
	}

	// When the player enters the collider
	// Show the prompts then delete it afterwards
	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Player") {
			mngr.ReloadPrompt (theText);
			mngr.currentLine = startLine;
			mngr.endAtLine = endLine;
			mngr.EnableTextBox ();

			if (destroyPromptArea) {
				Destroy (gameObject);
			}
		}
	}
}
