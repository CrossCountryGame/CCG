using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
//using GooglePlayGames.Android;
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
			#if UNITY_ANDROID
			
		//PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
		///	.EnableSavedGames()
			// registers a callback to handle game invitations received while the game is not running.
		//	.WithInvitationDelegate(<callback method>)
			// registers a callback for turn based match notifications received while the
			// game is not running.
		//	.WithMatchDelegate(<callback method>)
			// requests the email address of the player be available.
			// Will bring up a prompt for consent.
		//	.RequestEmail()
			// requests a server auth code be generated so it can be passed to an
			//  associated back end server application and exchanged for an OAuth token.
		//	.RequestServerAuthCode(false)
			// requests an ID token be generated.  This OAuth token can be used to
			//  identify the player to other services such as Firebase.
		//	.RequestIdToken()
		//	.Build();
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		//PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = false;
	

		#endif
			mng = this;
			DontDestroyOnLoad(gameObject);
	}

	public void ShowLeadboard()
	{

		Social.ShowLeaderboardUI ();

	}
	public void ShowAchievementsboard(){
		Social.ShowAchievementsUI();
	}

	public void ReportAchievement(string achievementID){
		Social.ReportProgress(achievementID,100.0f, (bool success) => {
		});
	}


	public void ReportScore (int score, string leaderboardID) {
		Debug.Log ("Reporting score " + score + " on leaderboard " + leaderboardID);
		Social.ReportScore (score, leaderboardID, success => {
			Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
	}
	void Start () {

		if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
		{
			Debug.Log("First Time Opening");
			PlayerPrefs.SetInt("CoinsMultiplier",1);
			PlayerPrefs.SetInt("MagnetTime",3);
			PlayerPrefs.SetInt ("SpeedBoost",3);
			PlayerPrefs.SetInt ("SpeedBoostPrice",0);
			PlayerPrefs.SetInt ("CoinMultiplierPrice",0);
			PlayerPrefs.SetInt ("MagnetTimePrice",0);

			//Set first time opening to false
			PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
			PlayerPrefs.SetString ("MusicState","on");
			PlayerPrefs.SetString ("SoundState","on");

			//Do your stuff here

		}
		else
		{
			Debug.Log("NOT First Time Opening");

			//Do your stuff here
		}
		Social.localUser.Authenticate (ProcessAuthentication);

	}
	void ProcessAuthentication (bool success) {
		if (success) {
			Debug.Log ("Authenticated, checking achievements");
		} else {
			Debug.Log ("Failed to authenticate");
		}     
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
		InfoCCG.infoccg.ResetValues ();
		SceneManager.LoadScene (1);

	}
	public void RunAgain(){
		isDead = false;
		SceneManager.LoadScene (2);
		InfoCCG.infoccg.ResetValues ();
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
		//LeaderboardManager.ShowLeaderboardUI ();

	}
	// Update is called once per frame
	void Update () {
		
	}

}
