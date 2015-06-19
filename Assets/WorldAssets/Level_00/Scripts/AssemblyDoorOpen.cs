using UnityEngine;
using System.Collections;

public class AssemblyDoorOpen : MonoBehaviour {
	bool open=false;
	bool close=false;
	public bool lockIt;
	public bool openOnTrigger=true;
	bool locked = false;
	public bool down=false;
	Vector3 startPos;
	Vector3 upPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		if (down == false) {
			upPos = transform.position + new Vector3 (0, 4.0f, 0);
		} else {
			upPos = transform.position + new Vector3 (0, -4.0f, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (locked == false) {
			if (open == true) {
				transform.position = Vector3.Lerp(transform.position,upPos , Time.deltaTime);

			}
		}

		if (close == true) {
			transform.position = Vector3.Lerp(transform.position,startPos , Time.deltaTime);
			if(lockIt==true)
			{
				locked=true;
			}
		}
	}

	void OnTriggerEnter(Collider enter)
	{
		if (openOnTrigger == true) {
			if (enter.CompareTag ("Player")) {
				//print ("enter");
				open=true;
				close=false;

			}
			if (enter.CompareTag ("Mover")) {
				//print ("enter");
				open=true;
				close=false;
			}
		}


	}
	void OnTriggerExit(Collider exit)
	{
		if (openOnTrigger == true) {
			if (exit.CompareTag ("Player")) {
				//print ("exit");
				open=false;
				close=true;
				//
			}
			if (exit.CompareTag ("Mover")) {
				//print ("exit");
				open=false;
				close=true;
				//
			}}

	
	}

	void openDoor(){

		open=true;
		close=false;
	}

	void closeDoor(){
		open=false;
		close=true;
	}
}
