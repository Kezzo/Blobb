using UnityEngine;
using System.Collections;

public class CanonAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item") {
			print ("Boom");
			other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward* 2000f);
		}
	}
}
