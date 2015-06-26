using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour
{
	public GameObject[] doorParts;

	public bool openDoor = false;

	[Range(1.0f,20.0f)]
	public float leftSpeed = 10f;

	[Range(1.0f,20.0f)]
	public float rightSpeed = 8f;

	float[] openingSteps = new float[2];

	public bool openHorizontal;

	bool isMoving;
	public bool isLocked = true;

	public float doorOpenedOffSet = 0.1f;  // to ensure no mesh clipping is happening

	Vector3[,] doorPositions;

	Vector3 previousRootPosition;

	void Start()
	{
		doorPositions = new Vector3[doorParts.Length,3];
		
		ConfigureBasePositions(true);
	}

	// Update is called once per frame
	void Update ()
	{
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
			openingSteps[0] = leftSpeed * Time.deltaTime;
			openingSteps[1] = rightSpeed * Time.deltaTime;
			
			if (!openDoor) 
			{
				for(int i=0; i<doorParts.Length; i++)
				{
					doorParts[i].transform.localPosition = Vector3.MoveTowards (doorParts[i].transform.localPosition, doorPositions[i,0], openingSteps[i]);
				}		
			}
			else
			{
				if(openHorizontal)
				{
					for(int i=0; i<doorParts.Length; i++)
					{
						doorParts[i].transform.localPosition = Vector3.MoveTowards (doorParts[i].transform.localPosition, doorPositions[i,1], openingSteps[i]);
					}
				}
				else
				{
					for(int i=0; i<doorParts.Length; i++)
					{
						doorParts[i].transform.localPosition = Vector3.MoveTowards (doorParts[i].transform.localPosition, doorPositions[i,2], openingSteps[i]);
					}
				}
			}
		}
		else
		{
			if(doorPositions[0,0] != doorParts[0].transform.position)
			{
				ConfigureBasePositions(false);
			}
		}

		previousRootPosition = this.transform.position;

	}

	void ConfigureBasePositions(bool isOnStart)
	{
		// Closed Door Positions
		for(int i=0; i<doorParts.Length; i++)
		{
			doorPositions[i,0] = doorParts[i].transform.localPosition;
		}

		// Opened Door Position
		doorPositions[0,1] = new Vector3(doorPositions[0,0].x - doorParts[0].GetComponent<MeshRenderer>().bounds.size.x + doorOpenedOffSet, 
		                                 doorPositions[0,0].y, 
		                                 doorPositions[0,0].z);

		doorPositions[0,2] = new Vector3(doorPositions[0,0].x, 
		                                 doorPositions[0,0].y - doorParts[0].GetComponent<MeshRenderer>().bounds.size.y - doorOpenedOffSet, 
		                                 doorPositions[0,0].z);

		if(doorParts.Length > 1)
		{
			doorPositions[1,1] = new Vector3(doorPositions[1,0].x + doorParts[1].GetComponent<MeshRenderer>().bounds.size.x - doorOpenedOffSet, 
			                                 doorPositions[1,0].y, 
			                                 doorPositions[1,0].z);
			
			doorPositions[1,2] = new Vector3(doorPositions[1,0].x, 
			                                 doorPositions[1,0].y - doorParts[1].GetComponent<MeshRenderer>().bounds.size.y - doorOpenedOffSet, 
			                                 doorPositions[1,0].z);
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

	void OpenDoor(){
		
		if(!isLocked)
		{
			openDoor=true;
		}
		else
		{
			isLocked = false;
		}
		
	}
}

