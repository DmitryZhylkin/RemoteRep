/*using UnityEditor;*/
using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System.Data.SqlClient;
public class Shop : MonoBehaviour {

	private Texture shop;
	private Texture Continue;
	private Texture mainmenu;
	private AudioClip menu_click;
	private Texture back;
	private Texture soon;
	private Texture use;
	private Texture equip;
	private Texture man_default;
	private Texture man_2;
	private Texture man_3;
	private Texture man_4;
	private Texture choose_skin;
	private Texture newbie;
	private Texture peasant;
	private Texture warrior;
	private Texture master;
	private Texture buy50;
	private Texture buy100;
	private Texture buy150;
	private int armor2 = 0;
	private int armor3 = 0;
	private int armor4 = 0;
	private int score = 0;
	private int up_coins = 0;
	public static string nick = "";
	int Checkpoint;

	void Start () 
	{
		Screen.showCursor = true;
		Debug.Log (nick);
		menu_click = (AudioClip)Resources.Load ("menu_click");
		shop = (Texture)Resources.Load ("shop");
		Continue = (Texture)Resources.Load ("continue");
		mainmenu = (Texture)Resources.Load ("main_menu");
		buy50 = (Texture)Resources.Load ("buy50");
		buy100 = (Texture)Resources.Load ("buy100");
		buy150 = (Texture)Resources.Load ("buy150");
		back = (Texture)Resources.Load ("shop_back");
		soon = (Texture)Resources.Load ("soon");
		use = (Texture)Resources.Load ("use");
		equip = (Texture)Resources.Load ("equip");
		man_default = (Texture)Resources.Load ("man");
		man_2 = (Texture)Resources.Load ("man_2");
		man_3 = (Texture)Resources.Load ("man_3");
		//man_4 = (Texture)Resources.Load ("man_4");
		choose_skin = (Texture)Resources.Load ("choose");
		newbie = (Texture)Resources.Load ("newbie");
		peasant =(Texture)Resources.Load ("peasant");
		warrior =(Texture)Resources.Load ("warrior");
		master =(Texture)Resources.Load ("master");

		string _strDBName = "URI=file:Assets/DB/Unity.db";
		IDbConnection _connection = new SqliteConnection (_strDBName);
		IDbCommand _command = _connection .CreateCommand ();
		string sql;
	
		_connection .Open ();
		
		sql = "Select Score, armor2, armor3, armor4 From Players where Login ='smile';";
		//sql = "Select Score, armor2, armor3, armor4 From Players where Login ="+nick+"';";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		IDataReader reader = _command.ExecuteReader();
		while (reader.Read()) 
		{
			score = reader.GetInt32(0);
			armor2 = reader.GetInt32 (1);
			armor3 = reader.GetInt32 (2);
			armor4 = reader.GetInt32 (3);
		}
		_command.Dispose ();
		_command = null;
		_connection .Close ();
		_connection = null;

		Debug.Log (" Score " + score + " Armor: " +armor2+ ", " + armor3 + ", "+armor4+"");
		}

	void Update () {
		Start ();
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 40;
		style.normal.textColor = Color.white;
		GUILayout.Label( "You have  " + score + " coins", style );
		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.DrawTexture (new Rect (520, 100, 200, 120), shop);
		GUI.DrawTexture (new Rect (450, 250, 300, 80), choose_skin);
		GUI.DrawTexture (new Rect (200, 350, 900, 550), back);
		GUI.DrawTexture (new Rect (250,360,110,50), newbie);
		GUI.DrawTexture (new Rect (440,360,110,50), peasant);
		GUI.DrawTexture (new Rect (640,360,110,50), warrior);
		GUI.DrawTexture (new Rect (840,360,110,50), master);
		GUI.DrawTexture (new Rect (230, 400, 130, 300), man_default);
		GUI.DrawTexture (new Rect (430, 400, 130, 300), man_2);
		GUI.DrawTexture (new Rect (550, 355, 280, 430), man_3);
		GUI.DrawTexture (new Rect (750, 355, 280, 430), man_3);

		/*if (GUI.Button (new Rect (430, 680, 150, 100), buy50)) {
			up_coins = score - 50;
			if (up_coins < 0) {
				EditorUtility.DisplayDialog("Not Enough money.",
				                            "Try to collect more on the next level.", "OK");
			}
			else {
				if ( EditorUtility.DisplayDialog("Do you really want to buy it?",
				                            "Are you sure you want to buy this skin for 50c?", "OK", "Cancel")){

			
				string _strDBName = "URI=file:Assets/DB/Unity.db";
				IDbConnection _connection = new SqliteConnection (_strDBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql;
			
				_connection .Open ();
			
					sql = "UPDATE Players SET armor2=1, Score =" + up_coins + " WHERE Login='smile';";
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				_command.Dispose ();
				_command = null;
				_connection .Close ();
				_connection = null;
					Debug.Log ("ok");}
			}
			}

		if (GUI.Button (new Rect (630, 680, 150, 100), buy100)) 
		{
			up_coins = score - 100;
			if (up_coins < 0) {
				EditorUtility.DisplayDialog("Not Enough money.",
				                            "Try to collect more on the next level.", "OK");
			}
			else {
				if ( EditorUtility.DisplayDialog("Do you really want to buy it?",
				                                 "Are you sure you want to buy this skin for 100c?", "OK", "Cancel")){
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
					sql = "UPDATE Players SET armor3=1,Score =" + up_coins + "  WHERE Login='smile';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
				Debug.Log ("ok");}
			}
		}

		if (GUI.Button (new Rect (830, 680, 150, 100), buy150)) 
		{
			up_coins = score - 150;
			if (up_coins < 0) {
				EditorUtility.DisplayDialog("Not Enough money.",
				                            "Try to collect more on the next level.", "OK");
			}
			else{
				if ( EditorUtility.DisplayDialog("Do you really want to buy it?",
				                                 "Are you sure you want to buy this skin for 150c?", "OK", "Cancel")){
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
					sql = "UPDATE Players SET armor4=1, Score =" + up_coins + " WHERE Login='smile';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			Debug.Log ("ok");
				}}
		}*/

		if (GUI.Button (new Rect (450, 740, 100, 75), equip)) 
		{
			// надеть на персонажа
		}

		if (GUI.Button (new Rect (250, 720, 100, 75), equip)) 
		{
			// надеть на персонажа
		}
		
		if (GUI.Button (new Rect (650, 740, 100, 75), equip)) 
		{
			// надеть на персонажа
		}
		if (GUI.Button (new Rect (850, 740, 100, 75), equip)) 
		{
			// надеть на персонажа
		}
		if (GUI.Button (new Rect (800, 800, 230, 100), Continue)) 
		{
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
		if (GUI.Button (new Rect (220, 810, 200, 75), mainmenu))
		{
			Application.LoadLevel("Main");
		}

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		GUI.EndGroup ();
	}
}
}