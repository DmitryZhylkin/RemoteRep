using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	private Texture Logo;
	public AudioClip menu_click;
	private Texture username;
	private Texture password;
	public string LoginString = "";
	public string PassString = "";
	private Texture forgot;
	private Texture login_new;
	private Texture signup;
	private GUIStyle transparent = new GUIStyle();

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
		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•');

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (490, 480, 100, 50), login_new, transparent)) {
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