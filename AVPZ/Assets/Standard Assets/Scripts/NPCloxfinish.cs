using UnityEngine;
using System.Collections;

public class NPCloxfinish : MonoBehaviour {


		
		public bool text=false;
	bool firstTime=true;
		
		void OnGUI(){
			if (text == true) {				
			Screen.showCursor=true;
				
				GUI.Box (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 150),""); 
				GUI.Label (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 300),"Поздравляю тебя, путник ! Ты смог преодолеть " +
					"этот нелегкий путь, но дальше тебя ждет ещё более тяжелые испытания. Дарю тебе за твои успехи эти новенькие доспехи. ");

				if (GUI.Button(new Rect(Screen.width/2 + 80 , Screen.height/2 + 75, 75, 40), "Спасибо"))
				{
					Time.timeScale = 1;
					text = false;
				Screen.showCursor=false;
				firstTime=false;
				}
				
			}
			
		}
		
		
		void OnTriggerEnter2D(Collider2D col){
			//if (col.gameObject.name == "npcLOX")
		if(col.tag == "NPCfinish"&&firstTime){text = true;
				Time.timeScale = 0;
				OnGUI();
			}
			
		}
		
		
	}