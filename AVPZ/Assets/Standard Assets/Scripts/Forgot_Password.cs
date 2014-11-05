using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Forgot_Password : MonoBehaviour {
	public string LoginString = "";
	public string EmailString = "";

	private Texture recovery_logo;
	private Texture username;
	private Texture email;
	private Texture send;
	private Texture cancel;

	public AudioClip menu_click;

	private GUIStyle transparent = new GUIStyle();

	//Загрузка текстур в память

	void Start()
	{ 
		recovery_logo = (Texture)Resources.Load ("recovery_logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
		username = (Texture)Resources.Load ("username_new");
		email = (Texture)Resources.Load ("e-mail");
		send = (Texture)Resources.Load ("send");
		cancel = (Texture)Resources.Load ("cancel");
	}

	void OnGUI() {
		
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000)); 
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (375, 100, 500, 130), recovery_logo);
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (460, 385, 100, 40), email);

		//Проверка правильности Логина (Буквы и "_") и Почты

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		LoginString= Regex.Replace(LoginString, @"[^a-zA-Z\_]", "");
		EmailString = GUI.TextField(new Rect(605, 390, 200, 30), EmailString, 25);

		bool isEmail = Regex.IsMatch(EmailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		if (isEmail) {
			Debug.Log("Формат правильный.");
		}

		//звук по клику

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (650, 480, 100, 50), send, transparent)) {

			// Проверка существования записи в БД
			IDataReader reader;
			string _DBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_DBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql = "SELECT Password FROM Players WHERE Login='"+ LoginString +"' AND Email='" +EmailString +"';";
			_connection .Open ();
			Debug.Log (sql);
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			reader = _command.ExecuteReader(); 

			// Если запись есть - отсылка письма с паролей на почту

			if( reader.Read() ) { 
				string pass = reader["Password"].ToString();
				MailMessage mail = new MailMessage();
				
				mail.From = new MailAddress("PI.12.2.Unity@gmail.com");
				mail.To.Add(EmailString);
				mail.Subject = "Password reminder";
				mail.Body = "You requested us to remind your password!\n\r Here it is:" + pass +"";
				
				SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
				smtpServer.Port = 587;
				smtpServer.Credentials = new System.Net.NetworkCredential("PI.12.2.Unity@gmail.com", "unitygame2014") as ICredentialsByHost;
				smtpServer.EnableSsl = true;
				ServicePointManager.ServerCertificateValidationCallback = 
					delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
				{ return true; };
				smtpServer.Send(mail);
				Debug.Log("Пароль выслан на почту.");
			}
			
			else {
				Debug.Log("Пользователь не существует либо введены неверные данные. Попробуйте еще раз.");
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				_command.Dispose ();
				_connection .Close ();
			}
			Application.LoadLevel("Login");
		}
		if (GUI.Button (new Rect (500, 485, 100, 50), cancel, transparent)) {
			Application.LoadLevel("Login");
		}

		GUI.EndGroup ();
	}
}
