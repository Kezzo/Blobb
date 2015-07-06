using UnityEngine;
using System.Collections;

public class leak_stopped : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider enter){

		if (enter.gameObject.tag == "MovingBlock") {
		//NextLevel
		
		}
	}
}
