using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class movementDebug : MonoBehaviour {

	public Text ytext;
	public Text xtext;
	public Text ztext;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ytext.text = "Y:" + Input.acceleration.y.ToString();
		xtext.text = "X:" + Input.acceleration.x.ToString();
		ztext.text = "Z:" + Input.acceleration.z.ToString();


	}
}
