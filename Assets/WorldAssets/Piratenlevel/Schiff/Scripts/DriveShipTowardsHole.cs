﻿using UnityEngine;
using System.Collections;

public class DriveShipTowardsHole : MonoBehaviour {

	public WaterBeiboot waterBeiboot;
	public Lore lorenControls;

	[Range(1.0f,20.0f)]
	public float speed = 1f;
	
	float step;

	bool drivingToHole;
	public Transform holeEntrance;
	Vector3 targetPosition;
	GameObject ship;

	// Update is called once per frame
	void Update () {
		if(drivingToHole)
		{
			step = speed * Time.deltaTime;
			//ship.transform.position = Vector3.MoveTowards (ship.transform.position, targetPosition, step);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "boat" && !drivingToHole)
		{
			waterBeiboot.disableLetBoatDown();
			lorenControls.enabled = true;
			lorenControls.rift = GameObject.Find("CenterEyeAnchor").transform;
			ship = other.gameObject;
			targetPosition = holeEntrance.position;
			StartCoroutine(startAfter(1.0f));
			//print ("drivin to hole");
		}
	}

	public IEnumerator startAfter(float secondsToWait)
	{
		yield return new WaitForSeconds(secondsToWait);
		drivingToHole = true;
	}
}
