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
	public AudioClip menu_click;
	private Texture username;
	private Texture password;
	private Texture email;
	private Texture submit;
	private Texture cancel;
	private GUIStyle transparent = new GUIStyle();

	void Start()
	{ 
		reg_logo = (Texture)Resources.Load ("reg_logo");
		menu_click = (AudioClip)Resources.Load("menu_click");
		username = (Texture)Resources.Load ("username_new");
		password = (Texture)Resources.Load("pass_new");
		email = (Texture)Resources.Load ("e-mail");
		submit = (Texture)Resources.Load ("submit");
		cancel = (Texture)Resources.Load ("cancel");
	}

	void CreateDB(){
				string _constr = "URI=file:Assets/DB/Unity.db";
				IDbConnection _dbc;
				IDbCommand _dbcm;
				IDataReader _dbr;
		
				string _strDBName = "URI=file:Assets/DB/Unity.db";
				IDbConnection _connection = new SqliteConnection (_strDBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql;
		
				_connection .Open ();
		
				sql = "CREATE TABLE Players (Login VARCHAR(15), Password VARCHAR(15), Email VARCHAR(25), Checkpoint VARCHAR(3), Score INT)";
				_command.CommandText = sql;
				_command.ExecuteNonQuery ();
				_command.Dispose ();
				_command = null;
				_connection .Close ();
				_connection = null;
		}

		void OnGUI() {
		
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000)); 
		GUI.DrawTexture (new Rect (400, 100, 450, 150), reg_logo);
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (450, 385, 130, 40), password);
		GUI.DrawTexture (new Rect (460, 440, 100, 40), email);

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		LoginString= Regex.Replace(LoginString, @"[^a-zA-Z\_]", "");
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•', 15);
		PassString= Regex.Replace(PassString, @"[^a-zA-Z0-9\_]", "");
		EmailString = GUI.TextField (new Rect (605, 445, 200, 30), EmailString,25);
		bool isEmail = Regex.IsMatch(EmailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		if (isEmail) {
			Debug.Log("Формат правильный.");
					//Отсылать письмо отсюда!
		}

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (630,500,180,50), submit, transparent)) {

			string _constr = "URI=file:Assets/DB/Unity.db";
			IDbConnection _dbc;
			IDbCommand _dbcm;
			IDataReader _dbr;
			
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "INSERT INTO Players (Login, Password, Email, Checkpoint, Score) VALUES ('"+LoginString+"', '"+PassString+"', '"+EmailString+"', '1', 0);";
			Debug.Log (sql);
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			Debug.Log("Вы успешно зарегистрировались.");

			MailMessage mail = new MailMessage();
			
			mail.From = new MailAddress("PI.12.2.Unity@gmail.com");
			mail.To.Add(EmailString);
			mail.Subject = "Test Mail";
			mail.Body = "This is for testing SMTP mail from GMAIL";
			
			SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential("PI.12.2.Unity@gmail.com", "unitygame2014") as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = 
				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{ return true; };
			smtpServer.Send(mail);
			Debug.Log("success");
			Application.LoadLevel("Login");
		}
		if (GUI.Button (new Rect (510, 500, 180, 50), cancel, transparent)) {
			Application.LoadLevel("Login");
		}
		GUI.EndGroup ();
	}
}
