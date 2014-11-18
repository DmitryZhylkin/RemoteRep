using UnityEngine;
using System.Collections;

public class Main: MonoBehaviour {

	private Texture Continue;
	private Texture New_game;
	private Texture Logout;
	private Texture Quit;
	private Texture Logo;
	private Texture LeaderBoard;
	public AudioClip menu_click;
	public static string nick = "";

	
	void Start()
	{ 
		LeaderBoard = (Texture)Resources.Load("leaderboard");
		Continue = (Texture)Resources.Load("continue"); 
		New_game = (Texture)Resources.Load ("new_game");
		Logout = (Texture)Resources.Load ("logout");
		Quit = (Texture)Resources.Load ("quit");
		Logo = (Texture)Resources.Load ("logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
	} 

	void OnGUI() {
		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.Label (new Rect (800,900,200,80),"<size=20>"+nick+"</size>");
		GUI.DrawTexture (new Rect (300, 100, 650, 150), Logo);

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (490, 400, 300, 80), Continue))
		{
			Application.LoadLevel ("Level_1");
		}
		if (GUI.Button (new Rect (480, 480, 300, 80), New_game)) 
		{
				Application.LoadLevel ("Difficulty");
		}
		if (GUI.Button (new Rect (505, 560, 300, 80), LeaderBoard))
		{
			Application.LoadLevel ("Leaderboard");
		}
		if (GUI.Button (new Rect (505, 640, 300, 80), Logout))
		{
			Application.LoadLevel ("Login");
		}
		if (GUI.Button (new Rect (520, 720, 300, 80), Quit)) 
		{
			Application.Quit ();
		}

		GUI.EndGroup ();
	}
}
