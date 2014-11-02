using UnityEngine;
using System.Collections;

public class Forgot_Password : MonoBehaviour {
	public string LoginString = "";
	public string EmailString = "";
	private Texture recovery_logo;
	public AudioClip menu_click;
	private Texture username;
	private Texture email;
	private Texture send;
	private Texture cancel;
	private GUIStyle transparent = new GUIStyle();

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

		EmailString = GUI.TextField(new Rect(605, 335, 200, 30), EmailString, 25);
		LoginString = GUI.TextField (new Rect (605, 390, 200, 30), LoginString,15);

		if (Input.GetButtonDown("Fire1"))
		{
			audio.PlayOneShot(menu_click);
			audio.volume = 0.3F;
		}

		if (GUI.Button (new Rect (490, 480, 100, 50), send, transparent)) {
			Application.LoadLevel("Login");
		}
		if (GUI.Button (new Rect (620, 485, 100, 50), cancel, transparent)) {
			Application.LoadLevel("Login");
		}

		GUI.EndGroup ();
	}
}
