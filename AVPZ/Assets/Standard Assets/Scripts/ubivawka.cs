using UnityEngine;
using System.Collections;

public class ubivawka : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "dieliquid"){
			coinsCollect.score=0;
			Application.LoadLevel("Level_1");
		}
		if(col.tag == "DieSpikes"){
			coinsCollect.score=0;
			Application.LoadLevel("Level_2");
		}
	}
}
