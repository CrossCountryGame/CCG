using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Store : MonoBehaviour {

	public GameObject noCoins;
	public int initialSpeedBoostPrice;
	public int initialCoinMultiplierPrice;
	public int initialMagnetTimePrice;

	public Text speedBoostPriceTXT;
	public Text MagnetTimeTXT;
	public Text CoinsMultiplierPriceTXT;

	 int SpeedBoostPrice;
	 int CoinMultiplierPrice;
	 int MagnetTimePrice;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("SpeedBoostPrice") == 0) {
			SpeedBoostPrice = initialSpeedBoostPrice;
		} else {
			SpeedBoostPrice = PlayerPrefs.GetInt ("SpeedBoostPrice");

		}
		if (PlayerPrefs.GetInt ("CoinMultiplierPrice") == 0) {
			CoinMultiplierPrice = initialCoinMultiplierPrice;
		} else {
			CoinMultiplierPrice = PlayerPrefs.GetInt ("CoinMultiplierPrice");

		}

		if (PlayerPrefs.GetInt ("MagnetTimePrice") == 0) {
			MagnetTimePrice = initialMagnetTimePrice;
		} else {
			MagnetTimePrice = PlayerPrefs.GetInt ("MagnetTimePrice");

		}


	}

	public void buySpeedBoost(){
		if (PlayerPrefs.GetInt ("wallet") > SpeedBoostPrice) {
			int PastSpeedBoost = PlayerPrefs.GetInt ("SpeedBoost");
			PlayerPrefs.SetInt ("SpeedBoost", PastSpeedBoost + 1);
			int LastWallet = PlayerPrefs.GetInt ("wallet");
			PlayerPrefs.SetInt ("wallet", LastWallet - SpeedBoostPrice);
			SpeedBoostPrice *= 2;
			PlayerPrefs.SetInt ("SpeedBoostPrice", SpeedBoostPrice);
			Manager.mng.ReportAchievement ("CgkI7Lrf5uUbEAIQAg");
		} else {
			noCoins.SetActive (true);
		}
	}

	public void buyMagnetTime(){
		if (PlayerPrefs.GetInt ("wallet") > MagnetTimePrice) {
			int PastMagnetTime = PlayerPrefs.GetInt ("MagnetTime");
			PlayerPrefs.SetInt ("MagnetTime", PastMagnetTime + 1);
			int LastWallet = PlayerPrefs.GetInt ("wallet");
			PlayerPrefs.SetInt ("wallet", LastWallet - MagnetTimePrice);
			MagnetTimePrice *= 2;
			PlayerPrefs.SetInt ("MagnetTimePrice", MagnetTimePrice);
			Manager.mng.ReportAchievement ("CgkI7Lrf5uUbEAIQAg");

		} else {
			noCoins.SetActive (true);
		}
	}

	public void buyCoinMultiplier(){
		if (PlayerPrefs.GetInt ("wallet") > CoinMultiplierPrice) {
			int PastCoinMultiplier = PlayerPrefs.GetInt ("CoinsMultiplier");
			PlayerPrefs.SetInt ("CoinsMultiplier", PastCoinMultiplier + 1);
			int LastWallet = PlayerPrefs.GetInt ("wallet");
			PlayerPrefs.SetInt ("wallet", LastWallet - CoinMultiplierPrice);
			CoinMultiplierPrice *= 2;
			PlayerPrefs.SetInt ("CoinMultiplierPrice", CoinMultiplierPrice);
			Manager.mng.ReportAchievement ("CgkI7Lrf5uUbEAIQAg");

		} else {
			noCoins.SetActive (true);
		}
	}
	// Update is called once per frame
	void Update () {
		CoinsMultiplierPriceTXT.text = CoinMultiplierPrice.ToString ();
		MagnetTimeTXT.text = MagnetTimePrice.ToString();
		speedBoostPriceTXT.text = SpeedBoostPrice.ToString ();
	}
}
