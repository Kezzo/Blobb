using UnityEngine;
using System.Collections;

public class DosenHandling : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//print(other.name);
		if(other.name == "Stand")
		{
			this.gameObject.layer = 15;
		
		}
	}
}
