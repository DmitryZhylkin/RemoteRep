using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public Transform tele_point;  // Объект выхода
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		// Проверяем кто вошел в телепорт, игрок?
		if (other.tag == "Player")
		{
			other.transform.position = tele_point.position;
		}
	}
}
