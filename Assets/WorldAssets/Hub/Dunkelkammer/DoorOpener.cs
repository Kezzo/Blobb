using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour
{
	public GameObject leftDoorPart;
	public GameObject rightDoorPart;

	public bool openDoor = false;

	[Range(1.0f,20.0f)]
	public float leftSpeed = 10f;

	[Range(1.0f,20.0f)]
	public float rightSpeed = 8f;

	public bool openHorizontal;

	bool isMoving;
	public bool isLocked = true;

	
	Vector3 leftDoorPosition;
	Vector3 rightDoorPosition;
	public float doorOpenedOffSet = 0.1f;  // to ensure no mesh clipping is happening

	Vector3[] doorPositions = new Vector3[6];

	float leftStep;
	float rightStep;

	Vector3 previousRootPosition;

	void Start()
	{
		ConfigureBasePositions(true);
	}

	// Update is called once per frame
	void Update ()
	{
		//ConfigureBasePositions();

		if(previousRootPosition != this.transform.position)
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}

		if(!isMoving && !isLocked)
		{
			float leftStep = leftSpeed * Time.deltaTime;
			float rightStep = rightSpeed * Time.deltaTime;
			
			if (!openDoor) 
			{
				leftDoorPart.transform.localPosition = Vector3.MoveTowards (leftDoorPart.transform.localPosition, doorPositions[0], leftStep);
				rightDoorPart.transform.localPosition = Vector3.MoveTowards (rightDoorPart.transform.localPosition, doorPositions[1], rightStep);		
			}
			else
			{
				if(openHorizontal)
				{
					leftDoorPart.transform.localPosition = Vector3.MoveTowards (leftDoorPart.transform.localPosition, doorPositions[2], leftStep);
					rightDoorPart.transform.localPosition = Vector3.MoveTowards (rightDoorPart.transform.localPosition, doorPositions[3], rightStep);
				}
				else
				{
					leftDoorPart.transform.localPosition = Vector3.MoveTowards (leftDoorPart.transform.localPosition, doorPositions[4], leftStep);
					rightDoorPart.transform.localPosition = Vector3.MoveTowards (rightDoorPart.transform.localPosition, doorPositions[5], rightStep);
				}
			}
		}
		else
		{
			if(leftDoorPosition != leftDoorPart.transform.position || rightDoorPosition != rightDoorPart.transform.position)
			{
				ConfigureBasePositions(false);
			}
		}

		previousRootPosition = this.transform.position;

	}

	void ConfigureBasePositions(bool isOnStart)
	{
		leftDoorPosition = leftDoorPart.transform.localPosition;
		rightDoorPosition = rightDoorPart.transform.localPosition;

		// Closed Door Positions
		doorPositions[0] = leftDoorPosition;
		doorPositions[1] = rightDoorPosition;
		
		// Opened Door Position
		doorPositions[2] = new Vector3(leftDoorPosition.x - leftDoorPart.GetComponent<MeshRenderer>().bounds.size.x + doorOpenedOffSet, 
		                               leftDoorPosition.y, 
		                               leftDoorPosition.z);

		doorPositions[3] = new Vector3(rightDoorPosition.x + rightDoorPart.GetComponent<MeshRenderer>().bounds.size.x - doorOpenedOffSet, 
		                               rightDoorPosition.y, 
		                               rightDoorPosition.z);

		doorPositions[4] = new Vector3(leftDoorPosition.x, 
		                               leftDoorPosition.y - leftDoorPart.GetComponent<MeshRenderer>().bounds.size.y - doorOpenedOffSet, 
		                               leftDoorPosition.z);
		
		doorPositions[5] = new Vector3(rightDoorPosition.x, 
		                               rightDoorPosition.y - rightDoorPart.GetComponent<MeshRenderer>().bounds.size.y - doorOpenedOffSet, 
		                               rightDoorPosition.z);
		
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

