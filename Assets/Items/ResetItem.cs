using UnityEngine;
using System.Collections;

public class ResetItem : MonoBehaviour {

	public Transform resetPosition;
	public string colliderName;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.name.Contains(colliderName))
		{
			this.transform.position = resetPosition.position;
		}
//		print (collision.collider.name);
	}
}
