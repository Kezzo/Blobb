using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnKanonenKugeln : MonoBehaviour {

	List<GameObject> cannonballs = new List<GameObject>();

	public GameObject currentPrefab;
	public GameObject prefabToSpawn;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Kanonenkugel"))
		{
			if(!cannonballs.Contains(other.gameObject))
			{
				cannonballs.Add(other.gameObject);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name.Contains("Kanonenkugel"))
		{
			if(cannonballs.Contains(other.gameObject))
			{
				cannonballs.Remove(other.gameObject);
			}

			if(cannonballs.Count < 1)
			{
				Destroy(currentPrefab);
				currentPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity) as GameObject;
			}
		}
	}
}
