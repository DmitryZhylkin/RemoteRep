using UnityEngine;
using System.Collections;

public class NPCLOX : MonoBehaviour {

	public bool text=false;
	 

	void OnGUI(){
		if (text == true) {
			 
			 
		 
			GUI.Box (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 150),""); 
			GUI.Label (new Rect (Screen.width/2 -25 , Screen.height/2 -25, 300, 300),"Приветствую тебя путник ! " +
				"Для того чтоб перемещаться по этим дорогам используй -W-A-S-D-, для прыжка -Space- ," +
				"а если на твоем пути попадется какое-то существо, то используй ЛКМ. Удачи в пути !");
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
		if(col.tag == "NPC"){text = true;
			Time.timeScale = 0;
			OnGUI();
		}
	
	}


}
