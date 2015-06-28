using UnityEngine;
using System.Collections;

public class golf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider enter){

		if (enter.CompareTag("Item")) {
			print ("golf");
		}
	}
}
