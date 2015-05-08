using UnityEngine;
using System.Collections;

public class WindFragBehaviour : MonoBehaviour {
	
	GameObject fragments;
	float step;
	Collider windFrag;
	Rigidbody windRigid;
	Rigidbody fragRigid;
	bool noGravity=false;

	// Use this for initialization
	void Start () {
		windFrag = GetComponent<Collider>();
		windRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerExit(Collider collider)
	{
		if(collider.name == "Turbine")
		{
			fragRigid.useGravity = true;
		}
	}
	void OnTriggerStay(Collider collider)
	{
		if(collider.name == "Turbine")
		{
			windRigid.useGravity = false;
			windRigid.velocity = new Vector3(0,0,0);
			windFrag.isTrigger = true;

			transform.RotateAround(transform.position,Vector3.up,10f);
			transform.RotateAround(transform.position,Vector3.left,10f);

			int randomPrim = Random.Range (1,5);
			switch(randomPrim)
			{
				case 1: fragments = GameObject.CreatePrimitive (PrimitiveType.Cube);
				break;
				case 2: fragments = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				break;
				case 3: fragments = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
				break;
				case 4: fragments = GameObject.CreatePrimitive (PrimitiveType.Capsule);
				break;
			}
			Vector3 fragTarget = new Vector3(collider.bounds.center.x,collider.bounds.center.y,collider.bounds.center.z);
			step = (3 * Time.deltaTime);
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, fragTarget, step); 

			fragments.tag = "Item";
			fragments.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			fragRigid = fragments.AddComponent<Rigidbody> ();
			//fragRigid.useGravity = false;
			fragments.transform.localPosition = new Vector3 (transform.localPosition.x+Random.Range(-1f,1f),transform.localPosition.y+Random.Range(-1f,1f),transform.localPosition.z+Random.Range(-1f,1f));
		}
	}
}
