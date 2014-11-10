using UnityEngine;
using System.Collections;

public class coinsCollect : MonoBehaviour
{


	public int score = 0;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "coin")
		{
			Destroy(other.gameObject);
			score += 1;
		}
	}

	void OnGUI() 
	{
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 40;
		style.normal.textColor = Color.white;
		GUILayout.Label( "Score: " + score, style );
		//score = GUI.Label (new Rect (0,0,100,20), "<size=100>Score</size>", style); 
	}
}