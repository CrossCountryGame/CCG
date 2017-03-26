using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour {

	int prefabsCleaned = 0; 
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.tag == "Trash"){
			Destroy (coll.gameObject.transform.parent.gameObject);
			prefabsCleaned++;
			//if(prefabsCleaned == 1){
			//RoadManager.rdmanager.MultipleSpawn (1);
			//	prefabsCleaned = 0;
			//}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
