using UnityEngine;
using System.Collections;

public class ParentPlayer : MonoBehaviour {

	public Transform targetPosition;
	public GameObject disable;

	bool alreadyParented = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Blobb" && !alreadyParented)
		{
			other.transform.root.transform.parent = this.transform.root.transform;
			if(other.GetComponentInParent<MakePlayerPersistent>().pirateLevelPartTwo)
			{
				this.transform.root.transform.position = targetPosition.position;
				this.transform.root.transform.rotation = targetPosition.rotation;
				disable.SetActive(false);
			}
			alreadyParented = true;
		}
	}

}
