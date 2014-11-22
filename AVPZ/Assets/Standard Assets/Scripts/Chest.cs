using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	public AudioClip chest_open;

	void Start()
	{
		chest_open = (AudioClip)Resources.Load ("chest");
	}

	void PlaySound(){
		audio.Pause ();
		audio.PlayOneShot (chest_open);
		audio.volume = 1F;
		audio.Play ();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100))
			{
				PlaySound();
				//animation.Play("Chest_Opening");
				Destroy(hit.transform.gameObject);
			}
		}
	}
	
	
	
}