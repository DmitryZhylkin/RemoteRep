using UnityEngine;
using System.Collections;

public class coinsCollect : MonoBehaviour
{
	int score=0;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "coin")
		{
			Destroy(other.gameObject);
			score+=1;
		}
	}
	void OnGUI() 
	{
		GUILayout.Label( "Score = " + score );
		
	}
}