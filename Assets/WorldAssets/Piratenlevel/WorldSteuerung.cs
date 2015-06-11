using UnityEngine;
using System.Collections;

public class WorldSteuerung : MonoBehaviour {

	public GameObject schiffsRad;
	public GameObject schiff;
	public GameObject worldParent;
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
			if (rotateWheel.isRotation == RotateWheel.IsRotation.Left) {
				worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, -rotateWheel.getWheelRotationSpeed() / 5.0f * Time.deltaTime);
				//this.transform.Rotate (Vector3.up, rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
			} else if (rotateWheel.isRotation == RotateWheel.IsRotation.Right) {
				worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, rotateWheel.getWheelRotationSpeed() / 5.0f * Time.deltaTime);
				//this.transform.Rotate (Vector3.up, -rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
			}
			
			this.transform.Translate(-this.transform.forward * 12.0f * Time.deltaTime);
		}
		
	}
	
	public void setMovement(bool shouldMove)
	{
		this.shouldMove = shouldMove;
	}
}
