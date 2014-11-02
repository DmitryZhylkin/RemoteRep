using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {
	private Texture diff;
	private Texture easy;
	private Texture medium;
	private Texture hard;
	private Texture back;
	public AudioClip menu_click;


	void Start()
	{ 
		diff = (Texture)Resources.Load ("difficulty");
		easy = (Texture)Resources.Load ("easy");
		medium = (Texture)Resources.Load ("medium");
		hard = (Texture)Resources.Load ("hard");
		back = (Texture)Resources.Load ("back");
		menu_click = (AudioClip)Resources.Load("menu_click");
	}

	void OnGUI() {

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.DrawTexture (new Rect (480, 100, 320, 150), diff);

		if (GUI.Button (new Rect (475, 380, 300, 100), easy)) {
			Application.LoadLevel ("Customize");
		}
		if (GUI.Button (new Rect (500, 480, 250, 70), medium)){
			Application.LoadLevel("Customize");
			Debug.Log("OK");
		}
		if (GUI.Button (new Rect (500, 560, 250, 70), hard)){
			Application.LoadLevel("Customize");
		}
		if (GUI.Button (new Rect (500, 640, 250, 70), back)) {
			Application.LoadLevel("Main");
		}

		GUI.EndGroup ();
	}
}
