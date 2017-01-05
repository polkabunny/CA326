using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed;

	private int drawDepth;
	private float alpha;
	public int fadeDir;

	void Start () {

		drawDepth = -1000;
		alpha = 1.0f;
		//fadeDir = -1;
	}

	//Set up Fading on the UI
	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	// Start the fade out
	public float BeginFade (int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}

	// Start fade out on the level
	void OnLevelWasLoaded(){
		BeginFade (-1);
	}
}
