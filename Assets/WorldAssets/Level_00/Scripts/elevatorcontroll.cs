using UnityEngine;
using System.Collections;

public class elevatorcontroll : MonoBehaviour {
	public GameObject door;
	public GameObject otherButton;

	public bool status=false;
	public bool controller=true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == true) {
			if (status == true) {
				door.SendMessage("openDoor");
			}
			if (status == false) {
				door.SendMessage("closeDoor");
			}
		}

	}

	void OnTriggerEnter(Collider enter)
	{
		status = !status;
		otherButton.SendMessage ("changeStatus");
	}

	void changeStatus(){

		status = !status;
	}


}
