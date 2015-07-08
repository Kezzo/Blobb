using UnityEngine;
using System.Collections;

public class EventTrigger3_PirateLevel : MonoBehaviour {

	public GameObject[] makeWorldGround;
	public CapsuleCollider deactivateTrigger;

	public BoxCollider buttonCollider;

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "piratenschiff")
		{
			other.transform.root.GetComponent<Schiffssteuerung>().setMovement(false);
			makeShipWalkable();
		}
	}
	void makeShipWalkable()
	{
		for(int i=0; i<makeWorldGround.Length; i++)
		{
			makeWorldGround[i].tag = "World";
			makeWorldGround[i].layer = 11;
		}
		
		deactivateTrigger.enabled = false;
		buttonCollider.enabled = true;
	}
}