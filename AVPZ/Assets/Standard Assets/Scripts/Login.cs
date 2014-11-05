using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System;

public class Login : MonoBehaviour {

	public string LoginString = "";
	public string PassString = "";

	private Texture Logo;
	private Texture username;
	private Texture password;
	private Texture forgot;
	private Texture login_new;
	private Texture signup;

	public AudioClip menu_click;

	private GUIStyle transparent = new GUIStyle();
	
	//Загрузка текстур в память

	void Start()
	{ 
		Logo = (Texture)Resources.Load ("logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
		username = (Texture)Resources.Load ("username_new");
		password = (Texture)Resources.Load("pass_new");
		forgot = (Texture)Resources.Load ("forgot_new");
		login_new = (Texture)Resources.Load ("login_new");
		signup = (Texture)Resources.Load ("signup");
	} 

	void OnGUI() {

		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.DrawTexture (new Rect (300, 100, 650, 150), Logo);
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (450, 385, 130, 40), password);

		//Проверка правильности Логина (Буквы и "_") и Пароля (Буквы, цифры, "_")

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		LoginString= Regex.Replace(LoginString, @"[^a-zA-Z\_]", "");
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•', 15);
		PassString= Regex.Replace(PassString, @"[^a-zA-Z0-9\_]", "");

		//звук по клику

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		// Проверка существования игрока в БД. Если да - вход в игру.

		if (GUI.Button (new Rect (490, 480, 100, 50), login_new, transparent)) {
			IDataReader reader;
			string _DBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_DBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql = "SELECT * FROM Players WHERE Login='"+ LoginString +"' AND Password='" +PassString +"';";
			_connection .Open ();
			Debug.Log (sql);
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
			reader = _command.ExecuteReader(); 
			if( reader.Read() ) { 
				Debug.Log("Вход выполнен.");
			}

			else {
			Debug.Log("Пользователь не существует либо введены неверные данные. Попробуйте еще раз.");
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_connection .Close ();
			}
			Application.LoadLevel("Main");
		}

		if(GUI.Button (new Rect(665,425,150,35),forgot, transparent)){
			Application.LoadLevel("Forgot_Password");
		}

		if (GUI.Button (new Rect (620, 480, 100, 50), signup, transparent)) {
			Application.LoadLevel("Register");
		}

		GUI.EndGroup ();
	}
	}