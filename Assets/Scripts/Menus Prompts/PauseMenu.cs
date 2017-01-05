using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	private AudioSource[] allAudioSources;
	private bool pauseCheck;
	public Rigidbody2D bridge;
	private string currentLevel;

	void Awake () {
		allAudioSources = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		pauseCheck = false;
		currentLevel = SceneManager.GetActiveScene ().name;
	}

	void PauseAllAudio () {
		foreach (AudioSource audioS in allAudioSources) {
			audioS.Pause ();
		}
	}

	void PlayAllAudio () {
		allAudioSources[1].Play ();
	}

	void PlayBridgeSound () {
		if(bridge.velocity.y != 0) {
			allAudioSources[0].Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		if(isPaused) {
			pauseMenuCanvas.SetActive(isPaused);
			Time.timeScale = 0f;
			PauseAllAudio ();
			pauseCheck = true;
		} else {
			pauseMenuCanvas.SetActive(isPaused);
			Time.timeScale = 1f;
			if (pauseCheck) {
				PlayAllAudio ();
				pauseCheck = !pauseCheck;
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	public void ResetLevel() {
		SceneManager.LoadScene (currentLevel); 
	}

	public void Resume() {
		isPaused = false;
		PlayAllAudio ();
	}

	public void Quit() {
		SceneManager.LoadScene (0);
	}
}
