using UnityEngine;
using System.Collections;

public class otkriva4ka : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="sunduk" && Input.GetKeyDown(KeyCode.E)){
			animation.Play("Green_Chest_Opening");
		}
	}
}
