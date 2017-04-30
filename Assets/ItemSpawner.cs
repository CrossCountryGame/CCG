using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public GameObject[] Items; //items or upgrades

	// Use this for initialization
	void Start () {
		if(Random.Range(1,10) > 7){
			Instantiate (Items[Random.Range(0,Items.Length - 1)],this.transform.position,this.transform.rotation);
			//Debug.Log ("ITEM!!!!");
			Debug.Log (Items.Length);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
