using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger1_PirateLevel : MonoBehaviour {

	bool alreadyTriggered;
	List<GameObject> cargoList = new List<GameObject>();

	public GameObject enemyShip;
	public GameObject[] makeWorldGround;
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
			other.transform.root.GetComponent<Schiffssteuerung>().setMovement(false);
			spawnEnemyShips(other.transform.root.transform);
			makeChildrenItems(other.transform.parent.gameObject);
			ExplodeAt(other.transform.parent.transform.position);
			makeShipWalkable();
			this.GetComponent<Collider>().enabled = false;

		}
		//print (other.name);
	}

	void makeShipWalkable()
	{
		for(int i=0; i<makeWorldGround.Length; i++)
		{
			makeWorldGround[i].tag = "World";
			makeWorldGround[i].layer = 11;
		}
	}

	void spawnEnemyShips(Transform shipTransform)
	{
		for(int i=0; i<2; i++)
		{
			GameObject spawnedEnemyShip = Instantiate(enemyShip, shipTransform.position, shipTransform.rotation) as GameObject;
			if(i % 2 == 0)
			{
				spawnedEnemyShip.transform.Translate(Vector3.left * 65, Space.Self);
			}
			else
			{
				spawnedEnemyShip.transform.Translate(Vector3.right * 65, Space.Self);
			}
		}

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
