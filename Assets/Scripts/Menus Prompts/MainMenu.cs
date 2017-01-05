using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void NewGame() {
		//Load scene 1 in the build by index - intended to be level 1
		SceneManager.LoadScene (1);
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
