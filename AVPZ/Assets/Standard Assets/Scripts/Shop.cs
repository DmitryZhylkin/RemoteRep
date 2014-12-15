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
	private Texture equip;
	private Texture man_default;
	private Texture man_2;
	private Texture man_3;
	private Texture man_4;
	private Texture choose_skin;
	private Texture newbie;
	private Texture peasant;
	private Texture warrior;
	private Texture buy100;
	private Texture buy150;
	private int armor2 = 0;
	private int armor3 = 0;
	private int armor4 = 0;
	private int score = 0;
	private int up_coins = 0;
	public static string nick = "";
	public static int Checkpoint;
	private bool enough = true;
	private bool bought = true;
	private bool canBuyWarrior = false;
	private bool canBuyPeasant = false;
	private bool skin1Chosen = false;
	private bool skin2Chosen = false;
	private bool skin3Chosen = false;

	void Start () 
	{
		Screen.showCursor = true;
		Debug.Log (nick);
		menu_click = (AudioClip)Resources.Load ("menu_click");
		shop = (Texture)Resources.Load ("shop");
		Continue = (Texture)Resources.Load ("continue");
		mainmenu = (Texture)Resources.Load ("main_menu");
		buy100 = (Texture)Resources.Load ("buy100");
		buy150 = (Texture)Resources.Load ("buy150");
		back = (Texture)Resources.Load ("shop_back");
		equip = (Texture)Resources.Load ("equip");
		man_default = (Texture)Resources.Load ("man");
		man_2 = (Texture)Resources.Load ("man_2");
		man_3 = (Texture)Resources.Load ("man_3");
		choose_skin = (Texture)Resources.Load ("choose");
		newbie = (Texture)Resources.Load ("newbie");
		peasant =(Texture)Resources.Load ("peasant");
		warrior =(Texture)Resources.Load ("warrior");
	}

	void Update () {
		string _strDBName = "URI=file:Assets/DB/Unity.db";
		IDbConnection _connection = new SqliteConnection (_strDBName);
		IDbCommand _command = _connection .CreateCommand ();
		string sql;
		_connection .Open ();
		sql = "Select Score From Players where Login ='"+nick+"';";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		IDataReader reader = _command.ExecuteReader();
		while (reader.Read()) 
		{
			score = reader.GetInt32(0);
		}
		_command.Dispose ();
		_command = null;
		_connection .Close ();
		_connection = null;
		Debug.Log (" Score: " + score);
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("Coneria");
		style.fontSize = 25;
		style.normal.textColor = Color.white;
		GUILayout.Label( "You have  " + score + " coins", style );
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.DrawTexture (new Rect (520, 100, 200, 120), shop);
		GUI.DrawTexture (new Rect (470, 250, 300, 80), choose_skin);
		GUI.DrawTexture (new Rect (250, 350, 700, 550), back);
		GUI.DrawTexture (new Rect (340,360,110,50), newbie);
		GUI.DrawTexture (new Rect (540,360,110,50), peasant);
		GUI.DrawTexture (new Rect (740,360,110,50), warrior);
		GUI.DrawTexture (new Rect (320, 400, 130, 300), man_default);
		GUI.DrawTexture (new Rect (530, 400, 130, 300), man_2);
		GUI.DrawTexture (new Rect (660, 355, 280, 430), man_3);

		if (GUI.Button (new Rect (520, 690, 150, 50), buy100, style)) 
		{
			up_coins = score - 100;
			if (up_coins < 0) {
				enough = false;
			}
			else
			{
				canBuyPeasant = true;
			}
		}

		if (GUI.Button (new Rect (730, 690, 150, 50), buy150, style)) 
		{
			up_coins = score - 150;
			if (up_coins < 0)
			{
				enough = false;
			}
			else
			{
				canBuyWarrior = true;
			}
		}
		if (GUI.Button (new Rect (340, 700, 100, 75), equip, style)) 
		{
			// надеть на персонажа стандартный скин
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			_connection .Open ();
			sql = "Select armor2 From Players where Login ='"+nick+"';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			IDataReader reader = _command.ExecuteReader();
			while (reader.Read()) 
			{
				armor2 = reader.GetInt32 (0);
			}
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			if (armor2 == 1)
			{
				skin1Chosen = true;
			}
			else
			{
				bought = false;
			}
		}

		if (GUI.Button (new Rect (540, 745, 100, 75), equip, style)) 
		{
			// надеть на персонажа второй скин
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			_connection .Open ();
			sql = "Select armor3 From Players where Login ='"+nick+"';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			IDataReader reader = _command.ExecuteReader();
			while (reader.Read()) 
			{
				armor3 = reader.GetInt32 (0);
			}
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			if (armor3 == 1)
			{
				skin2Chosen = true;
			}
			else
			{
				bought = false;
			}
		}
	
		if (GUI.Button (new Rect (750, 745, 100, 75), equip, style)) 
		{
			// надеть на персонажа третий скин
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			_connection .Open ();
			sql = "Select armor4 From Players where Login ='"+nick+"';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			IDataReader reader = _command.ExecuteReader();
			while (reader.Read()) 
			{
				armor4 = reader.GetInt32 (0);
			}
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			if (armor4 == 1)
			{
				skin3Chosen = true;
			}
			else
			{
				bought = false;
			}
		}
		if (GUI.Button (new Rect (760, 810, 230, 100), Continue, style)) 
		{
			if(Checkpoint==2){
				Application.LoadLevel("Level_2");
			}
		}
		if (GUI.Button (new Rect (250, 810, 200, 75), mainmenu, style))
		{
			Application.LoadLevel("Main");
		}
		if (!enough) 
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "Not Enough money. \n\nTry to collect more on \nthe next level.", style);
			if (GUI.Button (new Rect (35, 600, 120, 40), "\nOK. Thanks", style))
			{
				enough = true;
			}
		}
		if (canBuyPeasant)
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "You are going to buy\n skin 'Peasant'. \n\nDo you really want this?",style);
			if (GUI.Button (new Rect (20, 600, 80, 40), "\nOk.",style))
			{
				canBuyPeasant = false;
				string _strDBName = "URI=file:Assets/DB/Unity.db";
				IDbConnection _connection = new SqliteConnection (_strDBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql;
				
				_connection .Open ();
				
				sql = "UPDATE Players SET armor3=1, Score =" + up_coins + " WHERE Login='"+nick+"';";
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				_command.Dispose ();
				_command = null;
				_connection .Close ();
				_connection = null;
				Debug.Log ("ok");
			}
			else if (GUI.Button (new Rect (150, 600, 80, 40), "\nCancel",style))
			{
				canBuyPeasant = false;
			}
		}
		if (canBuyWarrior)
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "You are going to buy\nskin 'Warrior. \n\nDo you really want this?", style);
			if (GUI.Button (new Rect (20, 600, 80, 40), "\nOk.", style))
			{
				canBuyWarrior = false;
				string _strDBName = "URI=file:Assets/DB/Unity.db";
				IDbConnection _connection = new SqliteConnection (_strDBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql;
			
				_connection .Open ();
			
				sql = "UPDATE Players SET armor4=1, Score =" + up_coins + " WHERE Login='"+nick+"';";
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				_command.Dispose ();
				_command = null;
				_connection .Close ();
				_connection = null;
				Debug.Log ("ok");
			}
			else if(GUI.Button (new Rect (150, 600, 80, 40), "\nCancel",style ))
			{
				canBuyWarrior = false;
			}
		}
		if (skin1Chosen) 
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "You selected First skin\n 'Newbie'. Right choice \n for novice.", style);
			if (GUI.Button (new Rect (35, 600, 120, 40), "OK. Thanks", style)) 
			{
				skin1Chosen = false;
				armor2=1;
				armor3=0;
				armor4=0;
			}
		}
		if (skin2Chosen) 
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "You selected Second Skin\n 'Peasant'. Let him slash\nthe enemies!", style);
			if (GUI.Button (new Rect (35, 600, 120, 40), "OK. Thanks", style)) 
			{
				skin2Chosen = false;
				armor2=0;
				armor3=1;
				armor4=0;
			}
		}
		if (skin3Chosen) 
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "You selected third skin\n 'Warrior'. Very aggressive!", style);
			if (GUI.Button (new Rect (35, 600, 120, 40), "OK. Thanks", style)) 
			{
				skin3Chosen = false;
				armor2=0;
				armor3=0;
				armor4=1;
			}
		}
		if (!bought)
		{
			GUI.Box (new Rect (0, 500, 170, 150), ""); 
			GUI.Label (new Rect (0, 500, 200, 90), "  You should buy this\n  skin before equip.", style);
			if (GUI.Button (new Rect (35, 600, 120, 40), "OK. Thanks", style)) 
			{
				bought = true;
			}
		}
		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		GUI.EndGroup ();
	}
}