using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System.Data.SqlClient;

public class Customize: MonoBehaviour {

	private Texture man_default;
	public static int skin=2;
	private Texture man_2;
	private Texture man_3;
	private Texture newbie;
	private Texture peasant;
	private Texture warrior;
	private Texture char_choose;
	private Texture back;
	private Texture shop_back;
	private Texture confirm;
	public AudioClip menu_click;
	public Texture select;
	public static string nick = "";
	private int armor2 = 0;
	private int armor3 = 0;
	private int armor4 = 0;
	private GUIStyle transparent = new GUIStyle();
	private bool isBought = true;
	private bool skin1Chosen = false;
	private bool skin2Chosen = false;
	private bool skin3Chosen = false;

	void Start()
	{ 
		shop_back = (Texture)Resources.Load ("shop_back");
		man_default = (Texture)Resources.Load ("man");
		man_2 = (Texture)Resources.Load ("man_2");
		man_3 = (Texture)Resources.Load ("man_3");
		char_choose = (Texture)Resources.Load ("char_choose");
		back = (Texture)Resources.Load ("back");
		confirm = (Texture)Resources.Load ("confirm");
		menu_click = (AudioClip)Resources.Load("menu_click");
		newbie = (Texture)Resources.Load ("newbie");
		peasant =(Texture)Resources.Load ("peasant");
		warrior =(Texture)Resources.Load ("warrior");
		select =(Texture)Resources.Load ("select");
	} 
	void OnGUI() {
		transparent.font = (Font)Resources.Load("la_truite");
		transparent.fontSize = 25;
		transparent.normal.textColor = Color.white;

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}
		GUI.BeginGroup (new Rect (Screen.width / 2 - 500, Screen.height / 2 - 500, 1000, 1000));
		GUI.Box (new Rect (200, 230, 600, 550), "");
		//GUI.DrawTexture (new Rect (200, 350, 900, 550), shop_back);
		GUI.DrawTexture (new Rect (250,260,110,50), newbie);
		GUI.DrawTexture (new Rect (440,260,110,50), peasant);
		GUI.DrawTexture (new Rect (640,260,110,50), warrior);
		GUI.DrawTexture (new Rect (300,120,500,100), char_choose);
		GUI.DrawTexture (new Rect (230, 300, 130, 300), man_default);
		GUI.DrawTexture (new Rect (430, 300, 130, 300), man_2);
		GUI.DrawTexture (new Rect (550, 255, 280, 430), man_3);

		if (GUI.Button (new Rect (230, 600, 130, 60),select, transparent)) 
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "Select armor2 From Players where Login = '"+nick+"';";
			Debug.Log(sql);
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
			if (armor2 == 0)
			{
				isBought = false;
			}
			else if (armor2 == 1)
			{
				skin1Chosen = true;
			}
		}

		if (GUI.Button (new Rect (430, 600, 130, 60), select, transparent))
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "Select armor3 From Players where Login = '"+nick+"';";
			//sql = "Select Score, armor2, armor3, armor4 From Players where Login ="+nick+"';";
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
			if (armor3 == 0)
			{
				isBought = false;
			}
			else if (armor3 == 1)
			{
				skin2Chosen = true;
			}
		}
		if (GUI.Button (new Rect (630, 600, 130, 60), select, transparent)) 
		{
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "Select armor4 From Players where Login = '"+nick+"';";
			//sql = "Select Score, armor2, armor3, armor4 From Players where Login ='"+nick+"';";
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
			if (armor4 == 0)
			{
				isBought = false;
			}
			else if (armor4 == 1)
			{
				skin3Chosen = true;
			}
		}
		if (!isBought) 
		{
			GUI.Box (new Rect (350, 800, 290, 100), ""); 
			GUI.Label (new Rect (350, 800, 200, 150), "  You haven`t bought it. \n   You can take it in the shop.", transparent);
			if (GUI.Button (new Rect (450, 850, 95, 40), "<size=15>OK. Thanks</size>"))
			{
				isBought = true;
			}
		}
		if (skin1Chosen) 
		{
			GUI.Box (new Rect (350, 800, 330, 100), ""); 
			GUI.Label (new Rect (350, 800, 200, 150), "  You selected First skin 'Newbie'. \n   Right choice for novice.", transparent);
			if (GUI.Button (new Rect (450, 850, 95, 40), "<size=15>OK. Thanks</size>")) 
			{
				skin1Chosen = false;
				armor2=1;
				armor3=0;
				armor4=0;
			}
		}
		if (skin2Chosen) 
		{
			GUI.Box (new Rect (350, 800, 380, 100), ""); 
			GUI.Label (new Rect (350, 800, 200, 150), "  You selected Second Skin 'Peasant'. \n   Let him slash the enemies!", transparent);
			if (GUI.Button (new Rect (450, 850, 95, 40), "<size=15>OK. Thanks</size>")) 
			{
				skin2Chosen = false;
				armor2=0;
				armor3=1;
				armor4=0;
			}
		}
		if (skin3Chosen) 
		{
			GUI.Box (new Rect (350, 800, 350, 100), ""); 
			GUI.Label (new Rect (350, 800, 200, 150), "  You selected third skin 'Warrior'. \n  Very aggressive!", transparent);
			if (GUI.Button (new Rect (450, 850, 95, 40), "<size=15>OK. Thanks</size>")) 
			{
				skin3Chosen = false;
				armor2=0;
				armor3=0;
				armor4=1;
			}
		}
		if (GUI.Button (new Rect (220, 700, 230, 60), back, transparent)) 
		{
			Application.LoadLevel ("Difficulty");
		}

		if (GUI.Button (new Rect (600, 700, 230, 60), confirm, transparent))
		{
			Screen.showCursor=false;
			if(armor2 == 1){
				skin=1;
			}
			if(armor3==1){
				skin=2;
			}
			if(armor4==1){
				skin=3;
			}
			Application.LoadLevel("Level_1");
		}
			GUI.EndGroup ();
	}
}
