using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	
	private Rigidbody windRigid;
	[Range (-400, 400)]
	public float xAxis = 0;
	[Range (-400, 400)]
	public float yAxis = 0;
	[Range (-400, 400)]
	public float zAxis = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Item" || collider.gameObject.layer == LayerMask.NameToLayer("Player")) 
		{
			if(collider.name != "WindFrag")
			{
				windRigid = collider.GetComponent<Rigidbody>();
				windRigid.AddForce (1*xAxis,1*yAxis,1*zAxis);
			}

		}
	}
}
