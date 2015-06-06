using UnityEngine;
using System.Collections;

public class WheelTrigger : MonoBehaviour {

	public RotateWheel rotateWheel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains ("unterarm")) {
			print ("test");
			rotateWheel.setIfHandIsRight(true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name.Contains ("unterarm")) {
			rotateWheel.setIfHandIsRight(false);
		}
	}
}
