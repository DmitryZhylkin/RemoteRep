using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	private bool menu = false;         // приватная булеан переменная menu
	private bool options_on = false;   // приватная булеан переменная options_on
	private bool graphics = false;     // приватная булеан переменная options_on
	
	private Texture Continue;
	private Texture Options;
	private Texture Exit;
	private Texture Graphic;
	private Texture Back;
	private Texture _low;
	private Texture _medium;
	private Texture _high;
	private GUIStyle transparent = new GUIStyle();
	
	void  Start (){
		
		Continue = (Texture)Resources.Load("continue");
		Options = (Texture)Resources.Load("options");
		Exit = (Texture)Resources.Load("Exit");
		Graphic = (Texture)Resources.Load ("graphics");
		Back = (Texture)Resources.Load ("back");
		_low = (Texture)Resources.Load ("low");
		_medium = (Texture)Resources.Load ("medium");
		_high = (Texture)Resources.Load ("high");
	}
	
	void Update (){ 
		if (Input.GetButtonDown ("Exit")) { // если нажат Esc тогда
			if (!menu){                                 // если menu ложно тогда
				menu = true;                            // menu истинно
				menu_on ();                                 // вызываем функцию включения меню.
				return;
			}
			else {                                  // если menu истинно тогда
				menu = false;                           // menu ложно
				
				Time.timeScale = 1;                     // отключаем паузу.
				menu_off ();                                // вызываем функцию отключения меню.
				graphics = false;
				options_on = false;
				return;
			}
			
		}
	}
	
	void OnGUI () {
		if (menu) {                  // если меню истинно тогда
			Time.timeScale = 0;      // включаем паузу.
			
			if(!options_on){   // если options_on ложно тогда
				
				GUI.Box(new Rect(Screen.width/2-150,Screen.height/2-200,300,300), "");              //отрисовываем GUI.Box Меню
				
				if (GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-170,280,80), Continue, transparent )) { //нажата кнопка продолжить?
					menu = false;        // меню ложно
					Time.timeScale = 1;  // отключаем паузу.
					menu_off ();                     // вызываем функцию отключения меню.
					
				}
				if (GUI.Button(new Rect(Screen.width/2-85,Screen.height/2-85,230,70), Options,  transparent)) {   //нажата кнопка опции?
					options_on = true;
				}
				
				if (GUI.Button(new Rect(Screen.width/2-55,Screen.height/2+10,300,90), Exit,  transparent )) {    //нажата кнопка выход?
					Application.LoadLevel("Main"); //Выход из игры (работает только в скомпилированном проекте) 
				}
			}
			
			if(options_on){    // если options_on истинно тогда.
				
				if(!graphics){     // если graphics ложно тогда
					GUI.Box(new Rect(Screen.width/2-150,Screen.height/2-200,300,300), "");             //отрисовываем GUI.Box Опции
					
					if (GUI.Button(new Rect(Screen.width/2-90,Screen.height/2-170,280,80), Graphic, transparent)) {
						graphics = true;
					}
					if (GUI.Button(new Rect(Screen.width/2-70,Screen.height/2-0,280,80), Back, transparent)) {
						options_on = false;
					}
				}
				
				
			}
			if(graphics){      // если graphics истинно тогда
				GUI.Box(new Rect(Screen.width/2-150,Screen.height/2-200,300,300), "");           //отрисовываем GUI.Box Графика
				
				if (GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-180,220,60), _low, transparent )) {
					QualitySettings.SetQualityLevel(3,true);             // Устанавливаем настройки графики на 3
				} 
				if (GUI.Button(new Rect(Screen.width/2-80,Screen.height/2-120,220,60), _medium , transparent )) {
					QualitySettings.SetQualityLevel(2,true);             // Устанавливаем настройки графики на 2
				}
				if (GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-60,220,60), _high, transparent )) {
					QualitySettings.SetQualityLevel(1,true);             // Устанавливаем настройки графики на 1
				}
				if (GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+40,200,50), Back, transparent)) {
					graphics = false;
				}
				
			} 	
		}
	}
	
	void menu_on (){
		//GameObject.FindGameObjectWithTag("MainCamera").GetComponent(AudioListener).audio = true;  // отключаем звук.
	}
	
	void menu_off (){
		//GameObject.FindGameObjectWithTag("MainCamera").GetComponent(AudioListener).audio = false; // включаем звук.
	}
}
