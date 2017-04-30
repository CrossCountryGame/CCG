using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMainMenu : MonoBehaviour {

	[Header("Status")]
	public Text maxDistancetxt;
	public Text maxPuntuationtxt;
	public Text CoinsStatstxt;
	public Text CoinsMultipliertxt;

	[Header("Store")]
	public Text CoinsStoretxt;

	[Header("Settings")]
	public AudioSource MusicSRC;
	public InputField SubjectField;
	public InputField MessageField;
	public string StoreLink;
	string message;
	string subject;
	public string mail;
	public GameObject AdvertBook;
	public string LinkToBook;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetString ("MusicState") == "on"){
			MusicSRC.Play ();
		}
		StartCoroutine ("ShowAd");
		//if(){
			
		//}
		//LeaderboardManager.Init ();

	}
	IEnumerator ShowAd(){
		yield return new WaitForSeconds (2);
		AdvertBook.SetActive (true);
	}
	public void OpenLinkToBook(){
		Application.OpenURL (LinkToBook);

	}
	public void PlayButton(){
		Manager.mng.PlayGame();
		SceneManager.LoadScene (2);

	}

	#region [Envio de mensajes]
	public void SendMessage()
	{


		subject = MyEscapeURL(SubjectField.text);

		message = MyEscapeURL(MessageField.text);


		Application.OpenURL ("mailto:" + mail.ToString() + "?subject=" + subject.ToString() + "&body=" + message.ToString());

	}  

	string MyEscapeURL (string url)

	{

		return WWW.EscapeURL(url).Replace("+","%20");

	}
	#endregion

	#region [Activar y desactivar el audio]
	public void MusicStateTrue(){
		PlayerPrefs.SetString ("MusicState","on");
		MusicSRC.Play ();
		Debug.Log ("music - play");

	}
	public void MusicStateFalse(){
		PlayerPrefs.SetString ("MusicState","off");
		MusicSRC.Stop ();
		Debug.Log ("music - Stop");

	}
	public void SoundStateTrue(){
		PlayerPrefs.SetString ("SoundState","on");
		Debug.Log ("Sound - play");

	}
	public void SoundStateFalse(){
		PlayerPrefs.SetString ("SoundState","off");
		Debug.Log ("Sound - Stop");

	}
	#endregion

	public void RateUs(){
		Application.OpenURL(StoreLink);
	}

	public void LeaderBoardButton(){
		Manager.mng.ShowLeadboard ();
	}
	public void AchivementsButton(){
		Manager.mng.ShowAchievementsboard ();
	}
	// Update xis called once per frame
	void Update () {
		maxDistancetxt.text = "Max Distance Reached: "+ PlayerPrefs.GetInt ("maxDistance").ToString() + " Meters";
		maxPuntuationtxt.text = "HighScore: " +PlayerPrefs.GetInt ("maxPuntuation").ToString ();
		CoinsStatstxt.text = "Coins: " + PlayerPrefs.GetInt ("wallet").ToString ();
		CoinsStoretxt.text = "Coins: " + PlayerPrefs.GetInt ("wallet").ToString ();
		CoinsMultipliertxt.text = "Multiplier x" +PlayerPrefs.GetInt ("CoinsMultiplier");
	}
}
