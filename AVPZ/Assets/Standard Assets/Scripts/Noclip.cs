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
		if (other.tag == "Player" && GameObject.Find ("TrapBranch 0").collider2D.enabled == false) {
						GameObject.Find ("Pumpkin_Face1").collider2D.enabled = false;
					for (int i=0; i<16; i++)
						GameObject.Find ("TrapBranch " + i + "").collider2D.enabled = true;
						for (int i=0; i<2; i++)
								GameObject.Find ("Fence_Post Boss " + i + "").collider2D.enabled = true;
				}
		}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			GameObject.Find("Pumpkin_Face1").collider2D.enabled=true;
	}

}
