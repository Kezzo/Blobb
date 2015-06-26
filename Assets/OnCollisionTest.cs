using UnityEngine;
using System.Collections;

public class OnCollisionTest : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		print ("CollisionTest: "+collision.collider.name);
	}

	void OnTriggerEnter(Collider other)
	{
		print ("TriggerTest: "+other.name);
	}
}
