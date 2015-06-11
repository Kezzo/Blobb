using UnityEngine;
using System.Collections;

public class EventTrigger2_PirateLevel : MonoBehaviour {
	
	int enemyShipsSanked = 0;
	int cargoOnBoard = 0;
	bool allShipsSanked;
	bool allCargoOnBoard;

	public GameObject belowDeckDoor;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(allShipsSanked && allCargoOnBoard)
		{
			DoorOpener doorOpener = belowDeckDoor.GetComponent<DoorOpener>();
			doorOpener.isLocked = false;
			doorOpener.openDoor = true;
		}
	}

	public void shipSank()
	{
		enemyShipsSanked++;
		if(enemyShipsSanked > 1)
		{
			allShipsSanked = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Cargo")
		{
			cargoOnBoard++;
		}

		if(other.transform.parent.transform.childCount == cargoOnBoard)
		{
			allCargoOnBoard = true;
		}
	}
}
