using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class InfoCCG : MonoBehaviour {

	[Header ("Paths")]
	public GameObject[] path;
	//Player Stadistics.
	int puntuation;
	int distanceReached;
	int CoinsInGamePlay;
	bool NewMaxPuntuation = false;
	//Important to store-----------------
	int maxPuntuation;
	int MaxDistanceReached;
	int wallet;
	//------------

	int tempCoins;
	public static InfoCCG infoccg;	

	void Awake(){
		// whit this I can know if the first time played this game on the device
		if(PlayerPrefs.GetString("firstTime") == "yes"){
			PlayerPrefs.SetString ("firstTime","no");
		}
		infoccg = this;
	}

	void Start(){
		Load ();
	}
	void Load(){
		maxPuntuation = PlayerPrefs.GetInt ("maxPuntuation");
		wallet = PlayerPrefs.GetInt ("wallet");
		MaxDistanceReached = PlayerPrefs.GetInt ("maxDistance");
	}

	public void storeCurrentCoins(int c){
		tempCoins += c;
	}
	public void CompareData(int points, int dist){
		Debug.Log ("Max" + maxPuntuation);

		puntuation = points;
		distanceReached = dist;
		wallet = PlayerPrefs.GetInt ("wallet");
		PlayerPrefs.SetInt ("wallet", wallet + tempCoins);
		if (puntuation > maxPuntuation) {
			NewMaxPuntuation = true;
			PlayerPrefs.SetInt ("maxPuntuation",puntuation);
			maxPuntuation = PlayerPrefs.GetInt ("maxPuntuation");
			Debug.Log ("Max Reached" + maxPuntuation);
			Manager.mng.ReportScore (maxPuntuation,"CgkI7Lrf5uUbEAIQAA");
		}
		if(distanceReached > MaxDistanceReached){
			PlayerPrefs.SetInt ("maxDistance",distanceReached);
			MaxDistanceReached = PlayerPrefs.GetInt ("maxDistance");

		}
		//tempCoins = 0;
	}

	public void ResetValues(){
		tempCoins = 0;
	}

	#region[Get and Set]
	public int Puntuation{
		get { 
			return puntuation;
		}
		set{ 
			puntuation = value;
		}
	}

	public int DistanceReached{
		get { 
			return distanceReached;
		}
		set{ 
			distanceReached = value;
		}
	}
	public int Wallet{
		get { 
			return wallet;
		}
		set{ 
			wallet = value;
		}
	}
	public int TempCoins{
		get{ 
			return tempCoins;
		}
	}

	#endregion



}

