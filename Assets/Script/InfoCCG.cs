using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AppAdvisory.social;


public class InfoCCG : MonoBehaviour {

	//Player Stadistics.
	int puntuation;
	int distanceReached;
	int CoinsInGamePlay;

	bool NewMaxPuntuation = false;
	//Important to store-----------------
	int maxPuntuation;
	int MaxDistanceReached;
	int wallet;
	bool canSaveScore = false;
	bool canSaveDistance = false;
	//------------
	public static InfoCCG infoccg;	
	string dataPath;

	void Awake(){
		dataPath = Application.persistentDataPath + "/data.dat";
		infoccg = this;
	}

	void Start(){
		Load ();
	}

	public void CompareData(int points, int dist, int coins){
		puntuation = points;
		distanceReached = dist;
		wallet += coins;
		if (puntuation > maxPuntuation) {
			NewMaxPuntuation = true;
			canSaveScore = true;
			maxPuntuation = puntuation;
			//Manager.mng.NewHighscoreAlert.text = Manager.mng.AlertNewHighScoreText;
		} else {
			//Manager.mng.NewHighscoreAlert.text = "";
		}
		if(distanceReached > MaxDistanceReached){
			canSaveDistance = true;
		}

		Save ();
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

	#endregion
	void Save(){
		Debug.Log ("saving");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(dataPath);
		DataToSave data = new DataToSave();
		if(canSaveScore){
			data.MaxPuntuationSaved = maxPuntuation;
			LeaderboardManager.ReportScore (maxPuntuation);
		}
		if(canSaveDistance){
			data.MaxDistanceReachedSaved = MaxDistanceReached;

		}

		data.walletSaved += wallet;

		bf.Serialize(file, data);

		file.Close();
	}

	public void Load (){
		if(File.Exists(dataPath)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(dataPath, FileMode.Open);

			DataToSave data = (DataToSave) bf.Deserialize(file);

			maxPuntuation = data.MaxPuntuationSaved;
			MaxDistanceReached = data.MaxDistanceReachedSaved;
			wallet = data.walletSaved;

			file.Close();
		}else{
			maxPuntuation = 0;
		}
	}

}

[Serializable]
class DataToSave{
	public int MaxPuntuationSaved;
	public int MaxDistanceReachedSaved;
	public int walletSaved;
}