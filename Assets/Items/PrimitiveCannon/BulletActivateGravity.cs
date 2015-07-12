using UnityEngine;
using System.Collections;

public class BulletActivateGravity : MonoBehaviour 
{
	bool hasGravity = false;

	void OnCollisionEnter(Collision info)
	{
		if(!hasGravity)
		{
			this.GetComponent<Rigidbody>().useGravity = true;
			hasGravity = true;
		}
	}
}
