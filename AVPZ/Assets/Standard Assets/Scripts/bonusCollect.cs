using UnityEngine;
using System.Collections;

public class bonusCollect : MonoBehaviour
{
	
	public int bonus = 0;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "chest")
		{
			Destroy(other.gameObject);
			bonus += 10;
		}
	}
	
	void OnGUI() 
	{
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("la_truite");
		style.fontSize = 40;
		style.normal.textColor = Color.white;
		GUILayout.Label( "Bonus: " + bonus, style );
		//bonus= GUI.Label (new Rect (50,0,100,20), "<size=100>Score</size>", style); 
	}
}