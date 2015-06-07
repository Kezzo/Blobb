using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyBullets : MonoBehaviour {
	
	List<GameObject> bullets  = new List<GameObject>();

	void OnTriggerEnter(Collider other)
	{	
		if(other.name.Contains("Bullet"))
		{
			bullets.Add(other.gameObject);
			//print("bullet added!");
		}
	}
	
	public void destroyAllBulletsInList()
	{
		//print ("destroyBullets");
		foreach(GameObject bullet in bullets)
		{
			Destroy(bullet);
		}
	}
}
