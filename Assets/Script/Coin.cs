using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int CoinValue;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.tag == "Player"){
			PlayerController.player.plusPoints (CoinValue);
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
