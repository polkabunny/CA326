using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PromptManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;
	public string[] textPrompt;

	public int currentLine;
	public int endAtLine;

	public PlayerController player;

	public bool isActive;
	public bool stopPlayerMovement;

	private string currentLevel;

	// Use this for initialization
	void Start () {
		// Initialise everything we need
		currentLevel = SceneManager.GetActiveScene ().name;
		player = FindObjectOfType<PlayerController> ();

		// If there is a text file then start showing them on screen
		if (textFile != null) {
			textPrompt = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textPrompt.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}

	}

	// Update is called once per frame
	void Update() {
		//Check what level it is
		//Specific actions are linked to specific levels
		if (currentLevel == "Level1") {
			if (!isActive) {
				return;
			}

			theText.text = textPrompt [currentLine];
			if (Input.GetKeyDown (KeyCode.Return)) {
				currentLine += 1;
			}

			if (currentLine > endAtLine) {
				DisableTextBox ();
				currentLine = 0;
			}
		}
	}

	/* Text Box stuff */
	public void EnableTextBox (){
		textBox.SetActive (true);
		isActive = true;
		if (stopPlayerMovement) {
			player.canMove = false;
		}
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		player.canMove = true;
	}

	public void ReloadPrompt (TextAsset theText){
		if (theText != null) {
			textPrompt = new string[1];
			textPrompt = (theText.text.Split ('\n'));
		}
	}
}
