using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Manager : MonoBehaviour {

	public bool isPaused = false;
	bool PlayAtStart= false;
	public static Manager mng;

	public GameObject MainMenuPanel;
	public GameObject GamePlayPanel;
	[TextArea(3,10)]
	public string AlertNewHighScoreText;
	//GameOver Panel:
	[Header ("GameOver Panel")]
	public GameObject GameOverPanel;
	public Text NewHighscoreAlert;
	public Text ScoreReachedText;
	public Text DistanceReachedText;
	public Text CoinsReachedText;
	// Use this for initialization



	void Awake(){
		if(mng==null){
			mng = this;
			DontDestroyOnLoad(gameObject);
		}else if(mng!=this){
			Destroy(gameObject);
		}
	}
	void Start () {
		
		if (PlayAtStart) {
			MainMenuPanel.SetActive (false);
			GamePlayPanel.SetActive (true);

		} else {
			MainMenuPanel.SetActive (true);
			GamePlayPanel.SetActive (false);
			Pause ();
		}


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

	public void ResetScene(){
		PlayAtStart = false;
		SceneManager.LoadScene (0);

	}
	public void RunAgain(){
		PlayAtStart = true;
		SceneManager.LoadScene (0);
	}
	public void Gameover(){
		GameOverPanel.SetActive (true);
		ScoreReachedText.text = "Score: " + InfoCCG.infoccg.Puntuation;
		DistanceReachedText.text = "Distance " + InfoCCG.infoccg.DistanceReached;
		CoinsReachedText.text = ": " + InfoCCG.infoccg.Wallet;
		Pause ();
	}
	// Update is called once per frame
	void Update () {
	
	}

}
