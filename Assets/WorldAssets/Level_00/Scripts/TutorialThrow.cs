using UnityEngine;
using System.Collections;

public class TutorialThrow : MonoBehaviour {

	public Animation animation;

	// Use this for initialization
	void Start () 
	{
		animation["throw"].wrapMode = WrapMode.Once;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Sphere"))
		{
			other.attachedRigidbody.isKinematic = true;
			other.transform.parent = this.transform;
			animation.Play("throw");
		}
	}
}
