using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public Transform target;
	public Transform roadManager;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x,roadManager.position.y - 0.5f,target.position.z + 10f);
		transform.rotation = target.rotation;
	}
}
