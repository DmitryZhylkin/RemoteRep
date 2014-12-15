using UnityEngine;
using System.Collections;

public class Loop_Play : MonoBehaviour {
	private AudioClip clip;
	private static Loop_Play instance = null;
	public static Loop_Play Instance {
		get { return instance; }
	}
	void Start()
	{
		clip = (AudioClip)Resources.Load ("level2");
	}
	void Update(){
		if (Application.loadedLevelName == "Customize") 
		{
			audio.Pause();
		}
		if (Application.loadedLevelName == "Level_2") 
		{

		}

	}
	void Awake() {

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

	}
	void onGUI()
	{

	}
}
