using UnityEngine;
using System.Collections;

public class Schiffssteuerung : MonoBehaviour {

	public GameObject schiffsRad;
	//public GameObject schiff;
	//public GameObject worldParent;
	float previousRotationY;
	RotateWheel rotateWheel;

	bool shouldMove = true;
	bool firstGrabHappened;

	// Use this for initialization
	void Start () 
	{
		rotateWheel = schiffsRad.GetComponent<RotateWheel> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		print("isGrabbing: "+rotateWheel.isGrabbing);
		if (!firstGrabHappened && rotateWheel.isGrabbing) {
			firstGrabHappened = true;
		}
		else if (shouldMove && firstGrabHappened) {
			//print(rotateWheel.getWheelRotation());
			if(rotateWheel.getWheelRotation() < 180.0f)
			{
				this.transform.Rotate (Vector3.up, rotateWheel.getWheelRotation() / 4.0f * Time.deltaTime);
			}
			else if(rotateWheel.getWheelRotation() > 180.0f)
			{
				this.transform.Rotate (Vector3.up, -Mathf.Abs(360 - rotateWheel.getWheelRotation()) / 4.0f * Time.deltaTime);
//				print (Mathf.Abs(360 - rotateWheel.getWheelRotation()));
			}

			//Old unrelatistic Controls, commented out for documentation purposes
			/*if (rotateWheel.isRotation == RotateWheel.IsRotation.Left) {
				//worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, -rotateWheel.getWheelRotationSpeed() / 5.0f * Time.deltaTime);
				this.transform.Rotate (Vector3.up, rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
			} else if (rotateWheel.isRotation == RotateWheel.IsRotation.Right) {
				//worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, rotateWheel.getWheelRotationSpeed() / 5.0f * Time.deltaTime);
				this.transform.Rotate (Vector3.up, -rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
			}
			*/

			//if(rotateWheel.getWheelRotation

			this.transform.Translate(Vector3.forward * 12.0f * Time.deltaTime);


		}

	}

	public void setMovement(bool shouldMove)
	{
		this.shouldMove = shouldMove;
	}

}
