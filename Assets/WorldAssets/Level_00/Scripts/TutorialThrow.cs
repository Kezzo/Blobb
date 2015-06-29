using UnityEngine;
using System.Collections;

public class TutorialThrow : MonoBehaviour {

	public Animation anim;

	// Use this for initialization
	void Start () 
	{
		anim["throw"].wrapMode = WrapMode.Once;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Ball"))
		{
			other.attachedRigidbody.isKinematic = true;
			other.transform.parent = this.transform;
			anim.Play("throw");
		}
	}
}
