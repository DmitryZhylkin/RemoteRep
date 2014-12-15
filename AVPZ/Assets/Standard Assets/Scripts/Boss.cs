using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	private bool isFacingRight = false;
	float animTime = 0.6f;
	void Start(){
		//меняем направление движения персонажа
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector3 theScale = transform.localScale;
		//зеркально отражаем персонажа по оси Х
		theScale.x *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		transform.localScale = theScale;
	}
	void Update(){
		if(CharacterControl.Health<=0){
			
			Animator am = gameObject.GetComponent<Animator> ();
			am.enabled = true;
			animTime -= Time.deltaTime;
			if(animTime<=0){
				
				am.enabled=false;
				Destroy(this.gameObject);
				CharacterControl.Health=100;
				Application.LoadLevel("Main");
			}
			
		}
	}
}
