using UnityEngine;
using System.Collections;

public class NPCLOX2 : MonoBehaviour {
	
	public bool text=false;
	bool firstTime=true;
	
	void OnGUI(){
		if (text == true) {
			Screen.showCursor=true;
			GUI.Box (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 150),""); 
			GUI.Label (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 300),"Забыл тебе сказать ещё одну вещь, если ты вдруг найдешь монетки в своем пути, то ты всегда сможешь их обменять на полезные вещи. Монетки могут находится как у врагов, так и в различных тайниках, сундуках. Удачи !");
			if (GUI.Button(new Rect(Screen.width/2 + 80 , Screen.height/2 + 75, 75, 40), "Спасибо"))
			{
				Time.timeScale = 1;
				text = false;
				Screen.showCursor=false;
				firstTime=false;
			}
			
		}
		
		
		//900, 200, 300, 300
		//990, 400, 100, 50
		
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "NPC2"&&firstTime){text = true;
			Time.timeScale = 0;
			OnGUI();
		}

		
	}
	
	
}
