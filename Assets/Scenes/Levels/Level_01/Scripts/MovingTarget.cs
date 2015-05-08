using UnityEngine;
using System.Collections;

public class MovingTarget : MonoBehaviour {

	public GameObject door;
	public bool movingDoor = false;
	float step;

	float i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.x >= -7.00f && transform.localPosition.x <= -6.00f) {
			//i= -2f * Time.deltaTime;
			i= -0.1f;
		}
		else if(transform.localPosition.x <= -19.00f && transform.localPosition.x >=-20.0f)
		{
			//i = 2f * Time.deltaTime;
			i= 0.1f;
		}
		transform.position = new Vector3(transform.position.x +i,transform.position.y, transform.position.z);

		if (movingDoor) {
			step = 3 * Time.deltaTime;
			Vector3 doorTarget = new Vector3(0,-7.6f,0);
			Vector3 parentPos = transform.parent.transform.position;
			
			door.transform.position = Vector3.MoveTowards(door.transform.position, doorTarget + parentPos, step); 
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		movingDoor = true;
	}
}
