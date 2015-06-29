using UnityEngine;
using System.Collections;

public class TutorialBallThrow : MonoBehaviour {

	void FixedUpdate()
	{

	}

	void OnTriggerExit(Collider other)
	{
		if(other.name.Contains("Ball"))
		{
			//print ("ThrowBall");
			other.transform.parent = null;
			other.attachedRigidbody.isKinematic = false;
		}
	}
}
