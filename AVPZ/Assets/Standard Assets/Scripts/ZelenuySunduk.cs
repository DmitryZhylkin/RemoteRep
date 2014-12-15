using UnityEngine;
using System.Collections;

public class ZelenuySunduk : MonoBehaviour {
	private bool opened = false;
	private AudioClip clip;
	// Use this for initialization
	void Start () {
		clip = (AudioClip)Resources.Load ("chest2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			Animator am = gameObject.GetComponent<Animator>();
			am.enabled = true;
			if(!opened)
			{
				audio.PlayOneShot(clip);
				audio.volume = 1F;
				opened = true;
			}
		}
	}
}
