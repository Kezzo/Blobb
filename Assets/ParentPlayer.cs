using UnityEngine;
using System.Collections;

public class ParentPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Blobb")
		{
			other.transform.root.transform.parent = this.transform.root.transform;
		}
	}

}
