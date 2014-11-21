using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System;

public class LeaderBoard : MonoBehaviour {

	private Texture Back;
	IDataReader reader;
	string result="";
	//public AudioClip menu_click;
	void Start () {
		Back = (Texture)Resources.Load("back");
		//menu_click = (AudioClip)Resources.Load("menu_click");

		string _DBName = "URI=file:Assets/DB/Unity.db";
		IDbConnection _connection = new SqliteConnection (_DBName);
		IDbCommand _command = _connection .CreateCommand ();
		string sql = "SELECT Login, Score FROM Players ORDER BY Score DESC;";
		_connection .Open ();
		Debug.Log (sql);
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		reader = _command.ExecuteReader(); 

	}
	void OnGUI(){
		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		/*if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}*/
		if (GUI.Button (new Rect (50, 100, 180, 80), Back))
		{
			Application.LoadLevel ("Main");
		}
		/*while (reader.Read())
		{
			result += string.Format("Nick: {0}\nScore: {1}", reader.GetString(1), reader.GetString(2));
		}*/
		GUI.Label (new Rect(400,400,300,300),result);
		GUI.EndGroup ();
	}

}
