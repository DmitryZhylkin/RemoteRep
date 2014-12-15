using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Register : MonoBehaviour {
	public string LoginString = "";
	public string PassString = "";
	public string EmailString = "";

	private Texture reg_logo;
	private Texture username;
	private Texture password;
	private Texture email;
	private Texture submit;
	private Texture cancel;
	private bool empty = false;
	private bool exist = false;
	public AudioClip menu_click;

	private GUIStyle transparent = new GUIStyle();
	private GUIStyle style = new GUIStyle();

	void Start()
	{ 
		//Загрузка текстур и звука в память
		reg_logo = (Texture)Resources.Load ("reg_logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
		username = (Texture)Resources.Load ("username_new");
		password = (Texture)Resources.Load("pass_new");
		email = (Texture)Resources.Load ("e-mail");
		submit = (Texture)Resources.Load ("submit");
		cancel = (Texture)Resources.Load ("cancel");
	}

		void OnGUI() {
		// Параметры отображения текста
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 24;
		style.normal.textColor = Color.white;
		//создание области отображения элементов
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000)); 
		GUI.DrawTexture (new Rect (400, 100, 450, 150), reg_logo);
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (450, 385, 130, 40), password);
		GUI.DrawTexture (new Rect (460, 440, 100, 40), email);

		//Проверка правильности Логина (Буквы, цифры и _ ), Пароля (Буквы, цифры, _ ), Почты

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		LoginString= Regex.Replace(LoginString, @"[^a-zA-Z0-9\_]", "");
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•', 15);
		PassString= Regex.Replace(PassString, @"[^a-zA-Z0-9\_]", "");
		EmailString = GUI.TextField (new Rect (605, 445, 200, 30), EmailString,25);

		//Проверка правильного формата почты

		bool isEmail = Regex.IsMatch(EmailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		if (isEmail)
		{
			Debug.Log("Формат правильный.");
		}

		//звук по клику мышки

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}


		if (GUI.Button (new Rect (630,500,180,50), submit, transparent)) {

			//регистрация (запрос к БД). Если пользователь существует, вывести сообщение. Если нет - зарегистрировать.
			if (string.IsNullOrEmpty(LoginString) && string.IsNullOrEmpty(PassString) && string.IsNullOrEmpty(EmailString)){
				empty = true;
			}
			else{
				IDataReader reader;
				string _DBName = "URI=file:Assets/DB/Unity.db";
				IDbConnection _connection = new SqliteConnection (_DBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql = "SELECT * FROM Players WHERE Login='"+ LoginString +"' OR Email='" +EmailString +"';";
				_connection .Open ();
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				reader = _command.ExecuteReader(); 
				if(reader.Read()) 
				{ 
					exist = true;
				}
				else{
						string _strDBName = "URI=file:Assets/DB/Unity.db";
						IDbConnection _conn= new SqliteConnection (_strDBName);
						IDbCommand _comm = _connection .CreateCommand ();
						string req;
			
						_conn.Open ();
			
						req = "INSERT INTO Players (Login, Password, Email, Checkpoint, Score,Stars,armor2,armor3,armor4) VALUES ('"+LoginString+"', '"+PassString+"', '"+EmailString+"', '0', 0,0,0,0,0);";
						_comm.CommandText = req;
						_comm.ExecuteNonQuery ();
						_comm.Dispose ();
						_comm = null;
						_conn .Close ();
						_conn = null;

						//Отсылка письма на почту

						MailMessage mail = new MailMessage();
			
						mail.From = new MailAddress("PI.12.2.Unity@gmail.com");
						mail.To.Add(EmailString);
						mail.Subject = "Game Registration";
						mail.Body = "Thank you for playing our game! Hope you'll enjoy it.\n\r Your Login is:" + LoginString+ "\n\r Your Password is:" + PassString+"";
			
						SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
						smtpServer.Port = 587;
						smtpServer.Credentials = new System.Net.NetworkCredential("PI.12.2.Unity@gmail.com", "unitygame2014") as ICredentialsByHost;
						smtpServer.EnableSsl = true;
						ServicePointManager.ServerCertificateValidationCallback = 
							delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
						{ return true; };
						smtpServer.Send(mail);
						Debug.Log("Письмо отправлено");
						Application.LoadLevel("Login");
				}
			}
		}
		if (GUI.Button (new Rect (510, 500, 180, 50), cancel, transparent)) {
			Application.LoadLevel("Login");
		}
		if (empty) 
		{
			GUI.Box (new Rect (480, 600, 300, 100), ""); 
			GUI.Label (new Rect (480, 600, 250, 150), "   One or more fields are empty.\n                 Please fill all fields.", style);
			if (GUI.Button (new Rect (570, 675, 95, 40), "OK. Thanks", style))
			{
					empty = false;
			}
		}
		if (exist) 
		{
			GUI.Box (new Rect (480, 600, 300, 100), ""); 
			GUI.Label (new Rect (480, 600, 250, 150), " User or Email already exist.\n Or you entered wrong values.", style);
			if (GUI.Button (new Rect (570, 675, 95, 40), "OK. Thanks", style))
			{
				exist = false;
			}
		}
		GUI.EndGroup ();
	}
}
