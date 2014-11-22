using UnityEngine;
using System.Collections;

public class Loop_Play : MonoBehaviour {

	private static Loop_Play instance = null;
	public static Loop_Play Instance {
		get { return instance; }
	}
	void Update(){
		if (Application.loadedLevelName == "Level_1") {
			audio.Stop ();
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
}
