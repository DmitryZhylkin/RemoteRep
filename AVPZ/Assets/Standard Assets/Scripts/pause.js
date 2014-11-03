#pragma strict 

var paused : boolean = false; //объявляем булевую переменную паузы 
function Update ()   
{   
  if (Input.GetKeyDown(KeyCode.Escape)) //если нажата кнопка Escape 
  {   
  if(!paused) // и если пауза, то 
  {   
  Time.timeScale = 0; // время на 0 
  paused=true; //активация паузы 
  audio.Pause(); //звук тоже на паузу 
  Screen.showCursor = true; // и покажем курсор 
  } 
} 
} 
function OnGUI() //для GUI, что - то в роде меню 
  { 
  if(paused==true) //только если пауза равно(==) true 
  { 
  GUILayout.BeginArea(new Rect(Screen.width/2-50,Screen.height/2-60,100,300)); // создаем ареал с кнопкой 
if(GUILayout.Button ("Continue",GUILayout.Width(100),GUILayout.Height(25))) // сама кнопка+её нажатие 
{ 
  Time.timeScale = 1; //время на 1 
  paused=false; //снимаем с паузы 
  audio.Play(); //возобновляем звук 
  Screen.showCursor = false; // и убираем курсор 
  } 
  GUILayout.EndArea(); 
  } 
  }