using UnityEngine;
using System.Collections;


public class Door : MonoBehaviour {

	 
	// Use this for initialization
	void Start () {	
	}

	void Update () {	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
//GetComponent(Camera).enabled = false;
		//	other.am.enabled = true;
			Animator am = gameObject.GetComponent<Animator>();
		am.enabled = true;
		//GetComponent(animation, true);
		}
	}
}
