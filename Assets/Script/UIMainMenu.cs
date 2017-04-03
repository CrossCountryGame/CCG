using UnityEngine;
using System.Collections;

public class UIMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//LeaderboardManager.Init ();

	}
	public void PlayButton(){
		Manager.mng.PlayGame();
	}
	public void LeaderBoardButton(){
		//LeaderboardManager.ShowLeaderboardUI ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
