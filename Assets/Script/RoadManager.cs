using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RoadManager : MonoBehaviour {
	
	public List<GameObject> roads = new List<GameObject> ();
	//public GameObject[] prefabs;
	float spawnZ= 0.0f;
	private float LenghtZ = 0f;
	public int amnTilesOnScreen;
	public static RoadManager rdmanager;
	public Transform playerTransform;
	bool canGenerateObs = true;
	public int spawningTillObs;
	int allowedNormalSpawns;
	// Use this for initialization
	void Start () {
		rdmanager = this;
		for(int i = 0; i < amnTilesOnScreen; i++){
			GameObject go;
			go = Instantiate (roads[Random.Range(0,3)],transform.position,transform.rotation) as GameObject;
			go.transform.SetParent (transform);
			go.transform.position += new Vector3(0,0,LenghtZ);
			LenghtZ += 1.5f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if(playerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLenght)){
			SpawnRoad ();	
		}*/
	}

	public void MultipleSpawn(int amn){
		for(int i = 0; i < amn; i++){
			SpawnRoad ();
		}
	}
	public void SpawnRoad(int prefabIndex = -1){
		if(transform.childCount < amnTilesOnScreen){
			GameObject go;
			if (canGenerateObs) {
				go = Instantiate (roads [Random.Range (0, roads.Count)], transform.position, transform.rotation) as GameObject;
				if (go.name.Contains("Road4")) {
					canGenerateObs = false;
					allowedNormalSpawns = spawningTillObs; 
				}
			} else {
				go = Instantiate (roads[Random.Range(0,3)],transform.position,transform.rotation) as GameObject;
				allowedNormalSpawns--;
			}

			go.transform.SetParent (transform);
			go.transform.position += new Vector3(0,0,LenghtZ);
			LenghtZ += 1.5f;
			if(allowedNormalSpawns == 0){
				canGenerateObs = true;
			}
		}

	}
}
