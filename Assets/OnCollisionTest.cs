using UnityEngine;
using System.Collections;

public class OnCollisionTest : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		print (collision.collider.name);
	}
}
