using UnityEngine;
using System.Collections;

public class SpawnKanonenKugeln : MonoBehaviour {

	int currentCount;
	//public int maxCount = 16;

	public GameObject currentPrefab;
	public GameObject prefabToSpawn;

	void Update()
	{
		print (currentCount);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Kanonenkugel"))
		{
			currentCount++;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name.Contains("Kanonenkugel"))
		{
			currentCount--;

			if(currentCount < 1)
			{
				Destroy(currentPrefab);
				currentPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity) as GameObject;
			}
		}
	}
}
