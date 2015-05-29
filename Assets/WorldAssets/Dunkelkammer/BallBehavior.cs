using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	Rigidbody rb;
	public bool isActive = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive == true)
		{
			//do something
			rb.useGravity = true;
		}
	}

	void SetActiveStatus(bool value)
	{
		isActive = value;
	}

	void SelfDestruct()
	{
		Destroy(this.gameObject);
	}
}
