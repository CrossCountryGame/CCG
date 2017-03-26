using UnityEngine;
using System.Collections;

public class PathInfo : MonoBehaviour {

	public GameObject collisionDirection;

	public void FrontPath(){
		collisionDirection.SetActive (false);
		this.tag = "Untagged";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
