using UnityEngine;

using System.Collections;

public class PathSpawner : MonoBehaviour {

	public Transform positionY;
	public Transform[] pathSpawnPoint;

	public GameObject dangerBorder;

	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Player"){
			int randomPoint = Random.Range (0,pathSpawnPoint.Length);

			for(int i = 0; i < pathSpawnPoint.Length; i++){
				if (i == randomPoint) {
					int e = Random.Range (0, InfoCCG.infoccg.path.Length);
					GameObject currentpath = Instantiate (InfoCCG.infoccg.path [e], pathSpawnPoint [i].position, pathSpawnPoint [i].rotation) as GameObject;
					currentpath.transform.GetChild (0).gameObject.tag = "Ground";
					switch(i){
					case 0:
						currentpath.GetComponent<StuffSpawner> ().Spawn ("Front");
						break;
					case 1:
						currentpath.GetComponent<StuffSpawner> ().Spawn ("Right");
						break;
					case 2:
						currentpath.GetComponent<StuffSpawner> ().Spawn ("Left");
						break;
					}
					if(i == 0){
						GameObject PastPath = this.transform.parent.gameObject.transform.parent.gameObject;
						PastPath.GetComponent<PathInfo> ().FrontPath ();
					}
				} else {
					Vector3 rotation = pathSpawnPoint [i].rotation.eulerAngles;
					rotation.y += 90;
					Vector3 position = pathSpawnPoint [i].position;
					position.y = -0.258f;
					GameObject border = Instantiate (dangerBorder,position,Quaternion.Euler(rotation)) as GameObject;
					border.transform.GetChild (0).tag = "Obstacle";
					if(randomPoint == 0){
						border.transform.GetChild(0).tag = "Untagged";

					}
				}
			}
			/*switch(randomPoint){
			case 0:
				
				break;
			case 1:
				break;
			case 2: 
				break;
			}*/
		}	
	}
}
	