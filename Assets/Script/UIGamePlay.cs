using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour {
	public static UIGamePlay GPUI;
	[Header("Gameplay UI")]
	public Text Coinstxt;
	public Text Scoretxt;
	public Text coinsMultiplier;
	[Header("Pause UI")]
	public Text CoinsPausetxt;
	public Text DistancePausetxt;
	[Header ("GameOver Panel")]
	public GameObject GameOverPanel;
	public Text NewHighscoreAlert;
	public Text ScoreReachedText;
	public Text DistanceReachedText;
	public Text CoinsReachedText;
	public GameObject pauseButtonObj;
	[Header ("Book Panel")]

	public GameObject AdvertBook;
	int gameoverCounter =3;
	int currentGamerOver;
	public string LinkToBook;
	bool canShowAd = true;
	// Use this for initialization
	void Start () {
		GPUI = this;
	}
	public void PauseButton(){
		Manager.mng.Pause();

	}
	public void ReturnToMainMenuButton(){
		Manager.mng.ReturnToMainMenu();
		//Manager.mng.Pause ();
		canShowAd = true;



	}
	public void TryAgainButton(){
		Manager.mng.RunAgain ();
		canShowAd = true;

	}
	public void ShowGameOverPanel(){
		
		//PauseButton ();
		pauseButtonObj.SetActive (false);
		GameOverPanel.SetActive (true);
		ScoreReachedText.text = "Score: " + InfoCCG.infoccg.Puntuation;
		DistanceReachedText.text = "Distance " + InfoCCG.infoccg.DistanceReached;
		CoinsReachedText.text = ": " + InfoCCG.infoccg.TempCoins;

	}


	public void OpenLinkBook(){
		Application.OpenURL (LinkToBook);
	}
	// Update is called once per frame
	void Update () {
		Coinstxt.text = InfoCCG.infoccg.TempCoins.ToString();
		Scoretxt.text = InfoCCG.infoccg.Puntuation.ToString();
		CoinsPausetxt.text = "Coins: " + InfoCCG.infoccg.TempCoins.ToString();
		DistancePausetxt.text = "Distance: "+ PlayerPrefs.GetInt("tempDistance").ToString() + " m";
		coinsMultiplier.text = "x" + PlayerPrefs.GetInt ("CoinsMultiplier");
	}
}
