using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {
	float animTime = 3.03f;
	void Update(){
		if(CharacterControl.Health<=0){

			Animator am = gameObject.GetComponent<Animator> ();
			am.enabled = true;
			animTime -= Time.deltaTime;
			if(animTime<=0){
				 
				am.enabled=false;
				Destroy(this.gameObject);
			}
			
		}
	}
}
