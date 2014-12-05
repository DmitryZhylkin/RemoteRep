using UnityEngine;
using System.Collections;

public class Noclip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
				if (other.tag == "Player")
			GameObject.Find("Pumpkin_Face1").collider2D.enabled=false;

		}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			GameObject.Find("Pumpkin_Face1").collider2D.enabled=true;
	}
}
