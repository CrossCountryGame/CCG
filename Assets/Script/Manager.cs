﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AppAdvisory.social;

public class Manager : MonoBehaviour {

	public bool isPaused = false;
	public static Manager mng;
	public bool isDead = false;
	//public GameObject MainMenuPanel;
	//public GameObject GamePlayPanel;
	//[TextArea(3,10)]
	//public string AlertNewHighScoreText;

	// Use this for initialization



	void Awake(){
			mng = this;
			DontDestroyOnLoad(gameObject);
	}

	void Start () {
		Debug.Log ("Wallet: " + InfoCCG.infoccg.Wallet);
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

	public void ReturnToMainMenu(){
		Debug.Log ("Wallet: " + InfoCCG.infoccg.Wallet);

		SceneManager.LoadScene (1);

	}
	public void RunAgain(){
		Debug.Log ("Wallet: " + InfoCCG.infoccg.Wallet);
		isDead = false;
		SceneManager.LoadScene (2);
	}
	public void Gameover(){
		UIGamePlay.GPUI.ShowGameOverPanel ();
		isDead = true;
		Debug.Log ("GameOver");
		//Pause ();
	}

	public void PlayGame(){
		isDead = false;
		SceneManager.LoadScene (2);
	}
	//Call Leaderboard UI
	public void ShowLeaderBoardAndroid(){
		LeaderboardManager.ShowLeaderboardUI ();

	}
	// Update is called once per frame
	void Update () {
		
	}

}
