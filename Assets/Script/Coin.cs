using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int CoinValue;
	GameObject Character;
	private bool MagnetOn = false;
	private Vector3 initPos;
	// Use this for initialization
	private float lerpTime = 15.0f;
	private float currentLerpTime = 0;

	void Start () {
		Character = GameObject.Find ("Player");
		initPos = transform.position;
	}
	// Use this for initialization
	
	void OnTriggerEnter(Collider coll){
		if(coll.tag == "Player"){
			InfoCCG.infoccg.storeCurrentCoins (1 * PlayerPrefs.GetInt ("CoinsMultiplier"));
			Destroy (gameObject);
		}
		//if(coll.tag == "Magnet"){

		//	MagnetOn = true;
		//}
	}
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString ("MagnetAbility") == "on" && Vector3.Distance(PlayerController.player.gameObject.transform.position,this.transform.position) < 6f){
			currentLerpTime += Time.deltaTime * 20;
			if(currentLerpTime >= lerpTime){
				currentLerpTime = lerpTime;
			}

			float perc = currentLerpTime / lerpTime;
			transform.position = Vector3.Lerp (initPos,new Vector3(Character.transform.position.x,initPos.y,Character.transform.position.z),perc);

		}
	}
	
}

