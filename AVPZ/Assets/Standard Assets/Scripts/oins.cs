using UnityEngine;
using System.Collections;

public class oins : MonoBehaviour {

	 
 
			void OnTriggerExit2D(Collider2D other)
			{
				if (other.tag == "Enemy")
				{
			//foreach (Transform child in transform) {
			//child.position += Vector3.up * 10.0F;
		//}
			//	SpriteRenderer mama = gameObject.GetComponentInParent<SpriteRenderer>();
			//		 	mama.enabled = true;
			//	foreach (var ob in Parent.GetComponentsInChildren<Transform>())
			//		ild = ob.gameObject;

				SpriteRenderer test = gameObject.GetComponent<SpriteRenderer>();
				test.enabled = true;
				}
			}
}
