using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform LookAt;
	Vector3 startOffset;
	string direction = "Front";

	void Start(){
		startOffset = transform.position - LookAt.position;
	}

	public string Direction{
		set{ 
			direction = value;
		}
	}
	void Update(){
		
		switch(direction){
		case "Front":
			//Code
			transform.position = LookAt.position + startOffset;

			break;
		case "Left":
			//Code

			break;
		case "Back":
			//Code

			break;
		case "Right":
			//Code

			break;
		}
	}
 }