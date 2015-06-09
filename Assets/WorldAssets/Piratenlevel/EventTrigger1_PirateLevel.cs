using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger1_PirateLevel : MonoBehaviour {

	bool alreadyTriggered;
	List<GameObject> cargoList = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(!alreadyTriggered && other.name == "Cargo")
		{
			alreadyTriggered = true;
			transform.root.GetComponent<Schiffssteuerung>().setMovement(false);
			makeChildrenItems(other.transform.parent.gameObject);
			ExplodeAt(other.transform.parent.transform.position);
			this.GetComponent<Collider>().enabled = false;
		}
		//print (other.name);
	}

	void makeChildrenItems(GameObject parent)
	{
		cargoList.Clear();
		for(int i=0; i<parent.transform.childCount; i++)
		{
			cargoList.Add(parent.transform.GetChild(i).gameObject);
		}

		foreach(GameObject cargo in cargoList)
		{
			cargo.tag = "Item";
			cargo.layer = 9; //Layer 9 = Items
			cargo.GetComponent<Rigidbody>().isKinematic = false;
		}
	}

	void ExplodeAt( Vector3 explosionPosition)
	{
		//print ("IEnumerator started!");
		//print("Explode!");

		Collider[] colliders = Physics.OverlapSphere(explosionPosition, 10.0f);
		foreach (Collider hit in colliders) {
			if(hit.name.Contains("Cargo"))
			{
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				
				if (rb != null)
					rb.AddExplosionForce(50.0f, explosionPosition, 10.0f, 1.0f, ForceMode.VelocityChange);
			}
		}
	}

}
