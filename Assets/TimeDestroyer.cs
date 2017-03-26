using UnityEngine;
using System.Collections;

public class TimeDestroyer : MonoBehaviour {

	public float LifeTime = 10f;

	// Use this for initialization
	void Start()
	{
		Invoke("DestroyObject", LifeTime);
	}

	void DestroyObject()
	{
		if (!Manager.mng.isDead) {
			Destroy(gameObject);
		}
			
	}


	// Update is called once per frame
	void Update () {
	
	}
}
