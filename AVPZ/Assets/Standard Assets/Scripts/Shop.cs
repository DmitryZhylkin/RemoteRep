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
	private Texture buy;
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
	private int armor2 = 0;
	private int armor3 = 0;
	private int armor4 = 0;
	public static string nick = "";

	void Start () 
	{
		Screen.showCursor = true;
		menu_click = (AudioClip)Resources.Load ("menu_click");
		shop = (Texture)Resources.Load ("shop");
		Continue = (Texture)Resources.Load ("continue");
		mainmenu = (Texture)Resources.Load ("main_menu");
		buy = (Texture)Resources.Load ("buy");
		back = (Texture)Resources.Load ("shop_back");
		soon = (Texture)Resources.Load ("soon");
		use = (Texture)Resources.Load ("use");
		equip = (Texture)Resources.Load ("equip");
		man_default = (Texture)Resources.Load ("man");
		man_2 = (Texture)Resources.Load ("man_2");
		//man_3 = (Texture)Resources.Load ("man_3");
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
		
		sql = "Select armor2, armor3, armor4 From Players where Login = '"+nick+"';";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		IDataReader reader = _command.ExecuteReader();
		while (reader.Read()) 
		{
				armor2 = reader.GetInt32 (0);
				armor3 = reader.GetInt32 (1);
				armor4 = reader.GetInt32 (2);
		}
		_command.Dispose ();
		_command = null;
		_connection .Close ();
		_connection = null;

		Debug.Log ("Armor: " +armor2+ ", " + armor3 + ", "+armor4+"");
		}

	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (520,130,200,80),"<size=20>"+nick+"</size>");

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
		GUI.DrawTexture (new Rect (630, 400, 130, 300), man_2);
		GUI.DrawTexture (new Rect (830, 400, 130, 300), man_2);
		//GUI.Label (new Rect (230,350,100,50),"Default");

		if (GUI.Button (new Rect (250, 690, 110, 80), buy)) 
		{
		
		}
			Debug.Log (nick);
			//надеть скин


		if (GUI.Button (new Rect (450, 700, 90, 65), buy)) 
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "UPDATE Players SET armor2=1 WHERE Login='dima';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			GUI.RepeatButton (new Rect (450, 620, 90, 65), equip);
			Debug.Log("ok");
		}

		if (GUI.Button (new Rect (650, 700, 90, 65), buy)) 
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "UPDATE Players SET armor3=1 WHERE Login='dima';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
		}

		if (GUI.Button (new Rect (850, 700, 90, 65), buy)) 
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "UPDATE Players SET armor4=1 WHERE Login='dima';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
		}

		if (GUI.Button (new Rect (250, 740, 100, 75), equip)) 
		{
		}
		if (GUI.Button (new Rect (450, 740, 100, 75), equip)) 
		{
		}
		if (GUI.Button (new Rect (650, 740, 100, 75), equip)) 
		{
		}
		if (GUI.Button (new Rect (850, 740, 100, 75), equip)) 
		{
		}
		if (GUI.Button (new Rect (800, 800, 230, 100), Continue)) 
		{
			Application.LoadLevel("Level_2");
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
