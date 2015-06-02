using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	Rigidbody rb;
	public bool isActive = false;
	int seconds = Random.Range(1,5);
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

	void OnTriggerEnter (Collider objectCollider)
	{
		//print (objectCollider.name);
		if (objectCollider.name == "FloorPrototype64x01x64")
		{
			StartCoroutine(destructSequence());
			//SelfDestruct();
		}
	}

	IEnumerator destructSequence()
	{
		yield return new WaitForSeconds(seconds);
		SelfDestruct();
	}

}
