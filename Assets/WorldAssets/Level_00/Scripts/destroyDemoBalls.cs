using UnityEngine;
using System.Collections;

public class destroyDemoBalls : MonoBehaviour {
	public float destroytime=8.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider enter)
	{
		if (enter.CompareTag ("Item")) {
			Destroy (enter.gameObject, destroytime);
		}

	}
}
