using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour {
	public static UIGamePlay GPUI;
	[Header ("GameOver Panel")]
	public GameObject GameOverPanel;
	public Text NewHighscoreAlert;
	public Text ScoreReachedText;
	public Text DistanceReachedText;
	public Text CoinsReachedText;
	public GameObject pauseButtonObj;

	// Use this for initialization
	void Start () {
		GPUI = this;
	}
	public void PauseButton(){
		Manager.mng.Pause();

	}
	public void ReturnToMainMenuButton(){
		Manager.mng.ReturnToMainMenu();
		Manager.mng.Pause ();


	}
	public void TryAgainButton(){
		Manager.mng.RunAgain ();
		Manager.mng.Pause ();
	}
	public void ShowGameOverPanel(){
		//PauseButton ();
		pauseButtonObj.SetActive (false);
		GameOverPanel.SetActive (true);
		ScoreReachedText.text = "Score: " + InfoCCG.infoccg.Puntuation;
		DistanceReachedText.text = "Distance " + InfoCCG.infoccg.DistanceReached;
		CoinsReachedText.text = ": " + InfoCCG.infoccg.Wallet;
	}
	// Update is called once per frame
	void Update () {

	}
}
