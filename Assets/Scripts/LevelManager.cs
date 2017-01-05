using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;
    public GameObject respawnParticle;
    public float respawnDelay;
	public float ballRespawnDelay;
	public Rigidbody2D bridge;
	public AudioClip deathSound;
	public AudioClip ambience;
	private string currentLevel;
	public GameObject spikes;
	private RespawnBall ball;
	public GameObject ballRespawn;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
		currentLevel = SceneManager.GetActiveScene ().name;
		if (currentLevel == "level3") {
			ball = FindObjectOfType<RespawnBall> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentLevel != "Level3") {
			if (player.hasInteracted) {
				bridge.gravityScale = 0.033f;
			}
		} 
		else if (ball.set) {
			spikes.SetActive(false);
		}
	}

	// Move onto coroutine outside of Update()
	// Ensures it doesn't run on every frame
    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCo");
    }

    // Co-routine
    public IEnumerator RespawnPlayerCo() {
        Debug.Log("Player Respawn");
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = deathSound;
		audio.Play ();
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        player.GetComponent<Renderer>().enabled = true;
		audio.clip = ambience;
		audio.Play ();
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

	public void RespawnzBall() {
		StartCoroutine ("RespawnBallCo");
	}

	public IEnumerator RespawnBallCo() {
		Debug.Log ("Ball Respawn");
		//ball.enabled = false;
		//ball.GetComponent<Renderer>().enabled = false;
		ball.GetComponent<Rigidbody2D>().gravityScale = 0f;
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		yield return new WaitForSeconds (ballRespawnDelay);
		ball.transform.position = ballRespawn.transform.position;
		ball.GetComponent<Renderer>().enabled = true;
		Instantiate(respawnParticle, ballRespawn.transform.position, ballRespawn.transform.rotation);
	}
}
