using UnityEngine;
using System.Collections;

public class ubivawka : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "dieliquid"){
			Application.LoadLevel("Level_1");
		}
	}
}
