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
	private Texture quit;
	private AudioClip menu_click;
	private bool exist = true;

	private GUIStyle transparent = new GUIStyle();
	private GUIStyle style = new GUIStyle();


	void Start()
	{ 
		//Загрузка текстур и звука в память
		Logo = (Texture)Resources.Load ("logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
		username = (Texture)Resources.Load ("username_new");
		password = (Texture)Resources.Load("pass_new");
		forgot = (Texture)Resources.Load ("forgot_new");
		login_new = (Texture)Resources.Load ("login_new");
		signup = (Texture)Resources.Load ("signup");
		quit = (Texture)Resources.Load ("quit");
	} 

	void OnGUI() {
		// Параметры отображения текста
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 24;
		style.normal.textColor = Color.white;
		//создание области отображения элементов
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000));
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (300, 100, 650, 150), Logo);
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (450, 385, 130, 40), password);

		//Проверка правильности Логина (Буквы, цифры и _ ) и Пароля (Буквы, цифры и  _ )

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		LoginString= Regex.Replace(LoginString, @"[^a-zA-Z0-9\_]", "");
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•', 15);
		PassString= Regex.Replace(PassString, @"[^a-zA-Z0-9\_]", "");

		//звук по клику

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}
		// Проверка существования игрока в БД. Если да - вход в игру. Если нет - сообщение, что даныне не верные.

		if (GUI.Button (new Rect (450, 480, 100, 50), login_new, transparent)) {
			Main.nick=LoginString;
			Finish.nick=LoginString;
			Customize.nick = LoginString;
			Shop.nick=LoginString;
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
			if( reader.Read() ) 
			{
				Application.LoadLevel("Main");
			}
			else 
			{
				exist = false;
				_command.Dispose ();
				_connection .Close ();
			}
		}
		if (!exist) 
		{
			GUI.Box (new Rect (480, 600, 300, 100), ""); 
			GUI.Label (new Rect (480, 600, 250, 150), " User doesn`t exist.\n Or you entered wrong values.", style);
			if (GUI.Button (new Rect (570, 675, 95, 40), "OK. Thanks", style))
			{
				exist = true;
			}
		}
		if(GUI.Button (new Rect(665,425,150,35),forgot, transparent))
		{
			Application.LoadLevel("Forgot_Password");
		}

		if (GUI.Button (new Rect (580, 480, 100, 50), signup, transparent)) 
		{
			Application.LoadLevel("Register");
		}
		if (GUI.Button (new Rect (720, 480, 100, 50), quit, transparent)) 
		{
			Application.Quit();
		}

		GUI.EndGroup ();
	}
	}