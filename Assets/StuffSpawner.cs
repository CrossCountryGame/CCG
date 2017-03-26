using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StuffSpawner : MonoBehaviour {

	public GameObject[] obstacles; //obstacles
	public GameObject[] Items; //items or upgrades
	public GameObject[] coinsLines; // group of coins
	public Transform[] spawnPoints; // positions in the path
	//----------------------------------
	[Header ("Select in order 0-10")]
	[Range(0, 10)]
	public int percentageObstacles;
	[Range(0, 10)]
	public int percentageItems;
	[Range(0, 10)]
	public int percentageCoins;
	List<int> percentages = new List<int>();
	public bool firstPath = false;
	//-----------------------------------
	void Start(){
		if(firstPath){
			Spawn ("Front");
		}
	}
	public void Spawn (string Direction) {
		//order all percentages
		percentages.Add (percentageObstacles);
		percentages.Add (percentageItems);
		percentages.Add (percentageCoins);
		percentages.Sort ();

		//Start to spawn elements inside the positions.
		foreach(Transform pos in spawnPoints){
			int randomRange = Random.Range (1,10);
			int tempIndexItem = Random.Range (0,Items.Length);
			int tempIndexCoin = Random.Range (0,coinsLines.Length);
			int tempIndexObstacle = Random.Range (0,obstacles.Length);
			GameObject tempObj = new GameObject();
			//low percentage.
			if(randomRange > 0 && randomRange <= percentages[0]){
				int temp = percentages [0];
				if(temp == percentageObstacles){
					Vector3 rotation = obstacles [tempIndexObstacle].transform.rotation.eulerAngles;
					tempObj = Instantiate (obstacles[tempIndexObstacle],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageItems){
					Vector3 rotation = Items [tempIndexItem].transform.rotation.eulerAngles;
					tempObj = Instantiate (Items[tempIndexItem],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageCoins){
					Vector3 rotation = coinsLines [tempIndexCoin].transform.rotation.eulerAngles;
					tempObj = Instantiate (coinsLines[tempIndexCoin],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}
			}

			//Mid percentage.
			if(randomRange > percentages[0] && randomRange <= percentages[1]){
				int temp = percentages [1];
				if(temp == percentageObstacles){
					Vector3 rotation = obstacles [tempIndexObstacle].transform.rotation.eulerAngles;
					tempObj = Instantiate (obstacles[tempIndexObstacle],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageItems){
					Vector3 rotation = Items [tempIndexItem].transform.rotation.eulerAngles;
					tempObj = Instantiate (Items[tempIndexItem],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageCoins){
					Vector3 rotation = coinsLines [tempIndexCoin].transform.rotation.eulerAngles;
					tempObj = Instantiate (coinsLines[tempIndexCoin],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}
			}

			//High percentage.
			if(randomRange > percentages[1] && randomRange <= percentages[2]){
				int temp = percentages [2];
				if(temp == percentageObstacles){
					Vector3 rotation = obstacles [tempIndexObstacle].transform.rotation.eulerAngles;
					tempObj = Instantiate (obstacles[tempIndexObstacle],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageItems){
					Vector3 rotation = Items [tempIndexItem].transform.rotation.eulerAngles;
					tempObj = Instantiate (Items[tempIndexItem],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}else if(temp == percentageCoins){
					Vector3 rotation = coinsLines [tempIndexCoin].transform.rotation.eulerAngles;
					tempObj = Instantiate (coinsLines[tempIndexCoin],pos.position,Quaternion.Euler(rotation)) as GameObject;
				}
			}

			Vector3 tempRot = tempObj.transform.rotation.eulerAngles;
			string tempS = PlayerController.player.CurrentDirection;
			switch (tempS){
			case "Front":
				#region [Front]
				if(Direction == "Front"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,90,tempRot.z);
				}else if(Direction == "Right"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,180,tempRot.z);
				}else if(Direction == "Left"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,0,tempRot.z);
				}
				#endregion
				break;
			case "Right":
				#region [Right]
				if(Direction == "Front"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,180,tempRot.z);
				}else if(Direction == "Right"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,90,tempRot.z);
				}else if(Direction == "Left"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,90,tempRot.z);
				}
				#endregion				
			break;
			case "Left":
				#region [Left]
				if(Direction == "Front"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,0,tempRot.z);
				}else if(Direction == "Right"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,90,tempRot.z);
				}else if(Direction == "Left"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,90,tempRot.z);
				}
				#endregion				
			break;
			case "Back":
				#region [Back]
				if(Direction == "Front"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,0,tempRot.z);
				}else if(Direction == "Right"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,0,tempRot.z);
				}else if(Direction == "Left"){
				tempObj.transform.rotation = Quaternion.Euler (tempRot.x,180,tempRot.z);
				}
				#endregion				
			break;
			}



		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
