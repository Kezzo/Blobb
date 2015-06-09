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
		if (other.name == "unterarm_r") {
			//print ("test");
			rotateWheel.setRightHandIsRight(true);
		}
		else if(other.name == "unterarm_l") {
			rotateWheel.setLeftHandIsRight(true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name == "unterarm_r") {
			//print ("test");
			rotateWheel.setRightHandIsRight(false);
		}
		else if(other.name == "unterarm_l") {
			rotateWheel.setLeftHandIsRight(false);
		}
	}
}
