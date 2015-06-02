using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour
{

	public GameObject leftDoorPart;
	public GameObject rightDoorPart;
	public float DoorHeigt = 6f;
	public bool openDoor = false;

	[Range(1.0f,20.0f)]
	public float leftSpeed = 10f;

	[Range(1.0f,20.0f)]
	public float rightSpeed = 8f;


	private float leftStep;
	private float rightStep;

	// Update is called once per frame
	void Update ()
	{
		if (openDoor == true) {
			leftStep = leftSpeed * Time.deltaTime;
			rightStep = rightSpeed * Time.deltaTime;
			leftDoorPart.transform.position = Vector3.MoveTowards (leftDoorPart.transform.position, new Vector3 (leftDoorPart.transform.position.x, -DoorHeigt, leftDoorPart.transform.position.z), leftStep); 
			rightDoorPart.transform.position = Vector3.MoveTowards (rightDoorPart.transform.position, new Vector3 (rightDoorPart.transform.position.x, -DoorHeigt, rightDoorPart.transform.position.z), rightStep);
		} else {
			leftStep = leftSpeed * Time.deltaTime;
			rightStep = rightSpeed * Time.deltaTime;
			leftDoorPart.transform.position = Vector3.MoveTowards (leftDoorPart.transform.position, new Vector3 (leftDoorPart.transform.position.x, DoorHeigt, leftDoorPart.transform.position.z), leftStep); 
			rightDoorPart.transform.position = Vector3.MoveTowards (rightDoorPart.transform.position, new Vector3 (rightDoorPart.transform.position.x, DoorHeigt, rightDoorPart.transform.position.z), rightStep);
		}
	}

	void OnTriggerEnter (Collider objectCollider)
	{
		if (objectCollider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			openDoor = true;
		}
	}

	void OnTriggerStay (Collider objectCollider)
	{
		if (objectCollider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			openDoor = true;
		}
	}

	void OnTriggerExit (Collider objectCollider)
	{
		if(objectCollider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			openDoor = false;
		}
	}
}
