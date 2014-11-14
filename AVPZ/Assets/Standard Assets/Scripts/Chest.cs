using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100))
			{
				//animation.Play("Chest_Opening");
				Destroy(hit.transform.gameObject);
			}
		}
	}
	
	
	
}