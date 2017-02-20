using UnityEngine;
using System.Collections;

public class UIMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void PlayButton(){
		Manager.mng.PlayGame();
	}
	public void LeaderBoardButton(){
		Manager.mng.ShowLeaderBoardAndroid ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
