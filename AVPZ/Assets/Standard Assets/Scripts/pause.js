private var menu : boolean = false;         // приватная булеан переменная menu
private var options_on : boolean = false;   // приватная булеан переменная options_on
private var graphics : boolean = false;     // приватная булеан переменная options_on

function Update (){ 
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

function OnGUI () {
	if (menu) {                  // если меню истинно тогда
		Time.timeScale = 0;      // включаем паузу.
		
if(!options_on){   // если options_on ложно тогда

GUI.Box(Rect(Screen.width/2-150,Screen.height/2-200,300,300), "Меню");              //отрисовываем GUI.Box Меню

		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-170,280,80), "Продолжить")) { //нажата кнопка продолжить?
			menu = false;        // меню ложно
			Time.timeScale = 1;  // отключаем паузу.
menu_off ();                     // вызываем функцию отключения меню.

		}
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-85,280,80), "Опции")) {   //нажата кнопка опции?
		options_on = true;
		}
		
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-0,280,80), "Выход")) {    //нажата кнопка выход?

			Application.LoadLevel("Main"); //Выход из игры (работает только в скомпилированном проекте) 
		}
	   }  	   
	
if(options_on){    // если options_on истинно тогда.

if(!graphics){     // если graphics ложно тогда
GUI.Box(Rect(Screen.width/2-150,Screen.height/2-200,300,300), "Опции");             //отрисовываем GUI.Box Опции

        if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-170,280,80), "Графика")) {
                graphics = true;
        }
        if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-0,280,80), "Назад")) {
		        options_on = false;
		}
}


	}
if(graphics){      // если graphics истинно тогда
GUI.Box(Rect(Screen.width/2-150,Screen.height/2-200,300,300), "Графика");           //отрисовываем GUI.Box Графика

        if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-150,280,40), "Высокие")) {
                QualitySettings.SetQualityLevel(3,true);             // Устанавливаем настройки графики на 3
		} 
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-100,280,40), "Средние")) {
		        QualitySettings.SetQualityLevel(2,true);             // Устанавливаем настройки графики на 2
		}
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-50,280,40), "Низкие")) {
		        QualitySettings.SetQualityLevel(1,true);             // Устанавливаем настройки графики на 1
		}
		if (GUI.Button(Rect(Screen.width/2-140,Screen.height/2-0,280,80), "Назад")) {
		        graphics = false;
		}
		 	    	   
} 	
}
}

function menu_on (){
GameObject.FindGameObjectWithTag("MainCamera").GetComponent(AudioListener).pause = true;  // отключаем звук.
}

function menu_off (){
GameObject.FindGameObjectWithTag("MainCamera").GetComponent(AudioListener).pause = false; // включаем звук.
}