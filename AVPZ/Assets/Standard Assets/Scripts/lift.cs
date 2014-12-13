using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour {

	 
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){

			Animator am = gameObject.GetComponent<Animator>();
			am.enabled = true;

		}
	}
}
