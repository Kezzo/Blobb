using UnityEngine;
using System.Collections;

public class BallHandlingDosenwurf : MonoBehaviour {

	bool putToRight;
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
				other.transform.localPosition = new Vector3(-3.28f,7.16f, 7.15f);
			}
			else
			{
				other.transform.localPosition = new Vector3(-3.32f,7.16f, -6.91f);
			}
			
			putToRight = !putToRight;
		}
	}
}
