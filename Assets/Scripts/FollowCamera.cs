using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	private PlayerController player;
	public Vector3 offset;
	Vector3 targetPos;
	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;
	public bool puzzle;
	private string currentLevel;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		player = FindObjectOfType<PlayerController>();
		currentLevel = SceneManager.GetActiveScene ().name;
	}

	// FixedUpdate is called once per frame
	void FixedUpdate () {
		Debug.Log ("Current level name " + currentLevel);
		// Check bounds and do things accordingly
		if (player) {
			if(bounds) {
				transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), 
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
			}

			// Puzzle changes per level - actions change as a result
			if(puzzle) {
				if (currentLevel == "Level1") {
					if (transform.position.z < 16) {
						transform.position = new Vector3 (transform.position.x, transform.position.y, Mathf.Lerp (transform.position.z, -15, 100f * Time.fixedDeltaTime));
					}
				}
				else if(currentLevel == "Level2") {
					transform.position = new Vector3 (transform.position.x, transform.position.y, Mathf.Lerp (transform.position.z, -22, 100f * Time.fixedDeltaTime));
				}
				else if (currentLevel == "Level3") {
					transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, 5, 100f * Time.fixedDeltaTime), Mathf.Lerp (transform.position.z, -18, 100f * Time.fixedDeltaTime));
				}
			}

			/*else if(bounds) {
				transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), 
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
			} */

			// Keep camera following Player
			Vector3 posNoZ = transform.position;
			posNoZ.z = player.transform.position.z;

			Vector3 targetDirection = (player.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

		}
	}
}