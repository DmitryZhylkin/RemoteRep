using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System;

public class LeaderBoard : MonoBehaviour {

	private GUIStyle transparent = new GUIStyle();
	private Texture Back;
	IDataReader reader;
	string nickResult;
	string scoreResult;
	int j=0;
	char [] temp;
	//public AudioClip menu_click;
	void Start () {
		Back = (Texture)Resources.Load("back");
		//menu_click = (AudioClip)Resources.Load("menu_click");

		string _strDBName = "URI=file:Assets/DB/Unity.db";
		IDbConnection _connection = new SqliteConnection (_strDBName);
		IDbCommand _command = _connection .CreateCommand ();	
		_connection .Open ();		
		string sql = "SELECT Login, Score FROM Players ORDER BY Score DESC;";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		IDataReader reader = _command.ExecuteReader();
		while (reader.Read()&&j<10) 
		{
			for(int i=0;i<=1;i++){
				if(i==0){
					nickResult += reader.GetString(i);
					nickResult+='\n';
				}
				if(i==1){
					scoreResult += reader.GetString(i);
					scoreResult+='\n';
				}

				
				Debug.Log(nickResult);
				Debug.Log(i);
			}
			j++;
		}

		_command.Dispose ();
		_command = null;
		_connection .Close ();
		_connection = null;
	}
	void OnGUI(){
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 40;
		style.normal.textColor = Color.white;
		GUI.Box(new Rect(415,350,400,450), "<size=30>TOP-10 Players</size>"); 
		GUI.Label(new Rect(430,400,100,500),nickResult, style);
		GUI.Label(new Rect(760,400,100,500),scoreResult, style);
		if (GUI.Button (new Rect (50, 100, 180, 80), Back,transparent))
		{
			Application.LoadLevel ("Main");
		}
		GUI.EndGroup ();
	}

}
