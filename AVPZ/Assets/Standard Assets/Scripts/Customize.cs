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
	private Texture male_button_press;
	private Texture female_button_press;
	private Texture head;
	private Texture body;
	private Texture weapon;
	private Texture arrow_left;
	private Texture arrow_right;
	public AudioClip menu_click;
	private GUIStyle transparent = new GUIStyle();

	void Start()
	{ 
		character_man = (Texture)Resources.Load ("char_new");
		character_woman = (Texture)Resources.Load ("char_new");
		char_choose = (Texture)Resources.Load ("char_choose");
		male_label = (Texture)Resources.Load ("male_label");
		female_label = (Texture)Resources.Load ("female_label");
		back = (Texture)Resources.Load ("back");
		confirm = (Texture)Resources.Load ("confirm");
		menu_click = (AudioClip)Resources.Load("menu_click");
		male_button_press = (Texture)Resources.Load ("male_button_press");
		female_button_press = (Texture)Resources.Load ("female_button_press");
		head = (Texture)Resources.Load ("head");
		body = (Texture)Resources.Load ("body");
		weapon = (Texture)Resources.Load ("weapon");
		arrow_left = (Texture)Resources.Load ("arrow_left");
		arrow_right = (Texture)Resources.Load ("arrow_right");
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
		GUI.DrawTexture (new Rect (330, 340, 100, 300), character_man);
		GUI.DrawTexture (new Rect (650, 340, 100, 300), character_woman);
		GUI.DrawTexture (new Rect (890, 250, 100, 60), head);
		GUI.DrawTexture (new Rect (890, 380, 100, 60), body);
		GUI.DrawTexture (new Rect (880, 510, 125, 60), weapon);
		//Head arrows
		GUI.Button (new Rect (880, 320, 50, 50), arrow_left);
		GUI.Button (new Rect (950, 320, 50, 50), arrow_right);
		//Body arrows
		GUI.Button (new Rect (880, 450, 50, 50), arrow_left);
		GUI.Button (new Rect (950, 450, 50, 50), arrow_right);
		//Weapon arrows
		GUI.Button (new Rect (880, 580, 50, 50), arrow_left);
		GUI.Button (new Rect (950, 580, 50, 50), arrow_right);

		if (GUI.RepeatButton (new Rect (320, 250, 120, 60), male_label, transparent)) {
			GUI.RepeatButton (new Rect (320, 250, 120, 60), male_button_press, transparent);
		}
		if (GUI.RepeatButton (new Rect (640, 250, 130, 100), female_label, transparent)) {
			GUI.RepeatButton (new Rect (640, 250, 130, 100), female_button_press, transparent);
		}


		if (GUI.Button (new Rect (330, 700, 230, 60), back, transparent)) {
						Application.LoadLevel ("Difficulty");
		}

		if (GUI.Button (new Rect (600, 700, 230, 60), confirm, transparent)) {
			Screen.showCursor=false;
			Application.LoadLevel("Level_1");
		}
			GUI.EndGroup ();
	}
}
