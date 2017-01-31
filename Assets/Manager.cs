using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public bool isPaused = false;
	public static Manager mng;
	// Use this for initialization
	void Start () {
		mng = this;
		Pause ();
	}

	public void Pause(){
		if (isPaused == true) {
			Time.timeScale = 1;
			isPaused = false;
		} else {
			Time.timeScale = 0;
			isPaused = true;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

}
