using UnityEngine;
using System.Collections;

public class Customize: MonoBehaviour {

	private Texture character_man;
	private Texture character_woman;
	private Texture char_choose;
	private Texture male_label;
	private Texture female_label;
	private Texture back;
	private Texture confirm;
	public AudioClip menu_click;
	private GUIStyle transparent = new GUIStyle();

	void Start()
	{ 
		character_man = (Texture)Resources.Load ("char");
		character_woman = (Texture)Resources.Load ("char");
		char_choose = (Texture)Resources.Load ("char_choose");
		male_label = (Texture)Resources.Load ("male_label");
		female_label = (Texture)Resources.Load ("female_label");
		back = (Texture)Resources.Load ("back");
		confirm = (Texture)Resources.Load ("confirm");
		menu_click = (AudioClip)Resources.Load("menu_click");
	} 

	void OnGUI() {

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		GUI.BeginGroup (new Rect (Screen.width / 2 - 500, Screen.height / 2 - 500, 1000, 1000));
		GUI.Box (new Rect (250, 230, 600, 550), "");
		GUI.DrawTexture (new Rect (300,120,500,100), char_choose);
		GUI.Button (new Rect (320, 250, 120, 60), male_label, transparent);
		GUI.Button (new Rect (640,250,130,100), female_label, transparent);
		GUI.DrawTexture (new Rect (180, 340, 400, 300), character_man);
		GUI.DrawTexture (new Rect (510, 340, 400, 300), character_woman);

		if (GUI.Button (new Rect (330, 700, 230, 60), back, transparent)) {
						Application.LoadLevel ("Difficulty");
		}

		if (GUI.Button (new Rect (600, 700, 230, 60), confirm, transparent)) {
			Application.LoadLevel("Level_1");
			//Application.LoadLevel ("1");
			Debug.Log("OK!");
		}
			GUI.EndGroup ();
	}
}
