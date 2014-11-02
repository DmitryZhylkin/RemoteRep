using UnityEngine;
using System.Collections;

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
	void OnGUI() {
		
		GUI.BeginGroup (new Rect (Screen.width / 2 - 630, Screen.height / 2 - 500, 1000, 1000)); 
		GUI.DrawTexture (new Rect (400, 100, 450, 150), reg_logo);
		GUI.Box (new Rect (400, 300, 450, 250), "");
		GUI.DrawTexture (new Rect (450, 330, 130, 40), username);
		GUI.DrawTexture (new Rect (450, 385, 130, 40), password);
		GUI.DrawTexture (new Rect (460, 440, 100, 40), email);

		LoginString = GUI.TextField (new Rect (605, 335, 200, 30), LoginString, 15);
		PassString = GUI.PasswordField(new Rect(605, 390, 200, 30), PassString, '•');
		EmailString = GUI.TextField (new Rect (605, 445, 200, 30), EmailString,25);

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (630,500,180,50), submit, transparent)) {
			Application.LoadLevel("Login");
		}
		if (GUI.Button (new Rect (510, 500, 180, 50), cancel, transparent)) {
			Application.LoadLevel("Login");
		}
		GUI.EndGroup ();
	}
}
