using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
						for (int i=0; i<12; i++)
								Destroy (GameObject.Find ("Trap " + i + ""));
		
	}
}
