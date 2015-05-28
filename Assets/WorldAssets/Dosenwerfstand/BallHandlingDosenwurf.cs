using UnityEngine;
using System.Collections;

public class BallHandlingDosenwurf : MonoBehaviour {

	bool putToRight;

	public Transform rightPosition;
	public Transform leftPosition;
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Ball"))
		{
			other.transform.parent = transform;
			other.attachedRigidbody.velocity = Vector3.zero;
			if(putToRight)
			{
				other.transform.position = rightPosition.position;
			}
			else
			{
				other.transform.position = leftPosition.position;
			}
			
			putToRight = !putToRight;
		}
	}
}
