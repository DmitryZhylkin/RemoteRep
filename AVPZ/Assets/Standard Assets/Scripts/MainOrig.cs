using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System.Data.SqlClient;

public class MainOrig: MonoBehaviour {

	private Texture Continue;
	private Texture New_game;
	private Texture Logout;
	private Texture Quit;
	private Texture Logo;
	private Texture LeaderBoard;
	public AudioClip menu_click;
	public static string nick = "";
	public static int Checkpoint;
	
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
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "Select Checkpoint From Players where Login = '"+nick+"';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			IDataReader reader = _command.ExecuteReader();
			while (reader.Read()) 
			{
				Checkpoint = reader.GetInt32(0);
			}
			Debug.Log(Checkpoint);
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			switch (Checkpoint) {
			case 1: Application.LoadLevel("Level_1");
				break;
			case 2: Application.LoadLevel("Level_2");
				break;
			case 3: Application.LoadLevel("Level_3");
				break;
			default:Application.LoadLevel("Difficulty");
				break;
			}
		}
		if (GUI.Button (new Rect (480, 480, 300, 80), New_game)) 
		{
				Application.LoadLevel ("Difficulty");
		}
		if (GUI.Button (new Rect (485, 560, 300, 80), LeaderBoard))
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
