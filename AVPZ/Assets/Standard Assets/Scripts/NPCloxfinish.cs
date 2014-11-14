using UnityEngine;
using System.Collections;

public class NPCloxfinish : MonoBehaviour {


		
		public bool text=false;
		
		
		void OnGUI(){
			if (text == true) {
				
				
				
				GUI.Box (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 150),""); 
				GUI.Label (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 300),"Поздравляю тебя, путник ! Ты смог преодолеть " +
					"этот нелегкий путь, но дальше тебя ждет ещё более тяжелые испытания. Дарю тебе за твои успехи эти новенькие доспехи. ");

				if (GUI.Button(new Rect(Screen.width/2 + 80 , Screen.height/2 + 75, 75, 40), "Спасибо"))
				{
					Time.timeScale = 1;
					text = false;
				}
				
			}
			
			
			//900, 200, 300, 300
			//990, 400, 100, 50
			
		}
		
		
		void OnTriggerEnter2D(Collider2D col){
			//if (col.gameObject.name == "npcLOX")
			if(col.tag == "NPCfinish"){text = true;
				Time.timeScale = 0;
				OnGUI();
			}
			
		}
		
		
	}