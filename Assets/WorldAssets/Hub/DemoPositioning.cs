using UnityEngine;
using System.Collections;

public class DemoPositioning : MonoBehaviour {

	public Transform throwing;
	public Transform shooting;
	public Transform grenades;
	public Transform darkroom;

	GameObject player;

	public Reset_Button resetThrowing;
	public SpawnNewTargets resetShooting;
	public Reset_Button resetGrenades;

	public GameObject[] resetAdditional;
	Vector3[] resetPosition;
	Quaternion[] resetRotation;
	Rigidbody[] resetRigidbodyVel;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Blobb");

		resetPosition = new Vector3[resetAdditional.Length];
		resetRotation = new Quaternion[resetAdditional.Length];
		resetRigidbodyVel = new Rigidbody[resetAdditional.Length];

		for(int i=0; i<resetAdditional.Length; i++)
		{
			resetPosition[i] = resetAdditional[i].transform.position;
			resetRotation[i] = resetAdditional[i].transform.rotation;
			resetRigidbodyVel[i] = resetAdditional[i].GetComponent<Rigidbody>();
			//print(resetPosition[i]);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			changePositionOfPlayerTo(1);
			resetRange(1);
		}
		else if(Input.GetKey(KeyCode.Alpha2))
		{
			changePositionOfPlayerTo(2);
			resetRange(2);
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			changePositionOfPlayerTo(3);
			resetRange(3);
		}
		else if(Input.GetKey(KeyCode.Alpha4))
		{
			changePositionOfPlayerTo(4);
			// No reset needed, because its already resetting itself constantly.
		}
	}

	void changePositionOfPlayerTo(int positionID)
	{
		switch(positionID)
		{
			case 1: player.transform.position = throwing.position;
					player.transform.rotation = throwing.rotation;
				break;
			case 2: player.transform.position = shooting.position;
					player.transform.rotation = shooting.rotation;
					break;
			case 3: player.transform.position = grenades.position;
					player.transform.rotation = grenades.rotation;
					break;
			case 4: player.transform.position = darkroom.position;
					player.transform.rotation = darkroom.rotation;
					break;
		}
	}

	void resetRange(int rangeID)
	{
		switch(rangeID)
		{
			case 1: resetThrowing.resetGameObjects();
				break;
			case 2: resetShooting.resetTargets();
					for(int i=0; i<resetAdditional.Length; i++)
					{
						//print (resetAdditional[i].transform.position +" to "+ resetPosition[i]);
						resetAdditional[i].transform.position = resetPosition[i];
						resetAdditional[i].transform.rotation = resetRotation[i];
						resetRigidbodyVel[i].velocity = Vector3.zero;
					}
				break;
			case 3: resetGrenades.resetGameObjects();
				break;
		}


	}
}
