using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger2_PirateLevel : MonoBehaviour {
	
	int enemyShipsSanked = 0;
	int cargoOnBoard = 0;
	bool allShipsSank;
	bool allCargoOnBoard;

	public GameObject belowDeckDoor;

	SinkShip[] sinkShipScripts = new SinkShip[2];

	// Use this for initialization
	void Start () 
	{
		print("Start");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(sinkShipScripts[0].getIsSinking() && sinkShipScripts[1].getIsSinking() && !allShipsSank)
		{
			print ("All Ships sank!");
			allShipsSank = true;
		}

		if(allShipsSank && allCargoOnBoard)
		{
			print ("Door Opened to next Part!");
			DoorOpener doorOpener = belowDeckDoor.GetComponent<DoorOpener>();
			doorOpener.isLocked = false;
			doorOpener.openDoor = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(!allCargoOnBoard)
		{
			if(other.name == "Cargo")
			{
				cargoOnBoard++;
				print ("Cargo Added! "+cargoOnBoard);
			}
			
			if(cargoOnBoard == 6)
			{
				allCargoOnBoard = true;
				print ("all Cargo on Board!");
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "Cargo" && !allCargoOnBoard)
		{
			cargoOnBoard--;
			print ("Cargo removed! "+cargoOnBoard);
		}
	}

	public void setEnemyShips(GameObject enemyShip1, GameObject enemyShip2)
	{
		sinkShipScripts[0] = enemyShip1.GetComponent<SinkShip>();
		sinkShipScripts[1] = enemyShip2.GetComponent<SinkShip>();
	}
}
