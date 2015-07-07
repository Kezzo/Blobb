using UnityEngine;
using System.Collections;

public class PreparePartTwo : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Blobb")
		{
			other.GetComponentInParent<GameManagement>().pirateLevelPartTwo = true;
		}
	}
}
