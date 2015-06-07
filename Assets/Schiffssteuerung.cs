using UnityEngine;
using System.Collections;

public class Schiffssteuerung : MonoBehaviour {

	public GameObject schiffsRad;
	public GameObject schiff;
	public GameObject worldParent;
	float previousRotationY;
	RotateWheel rotateWheel;

	// Use this for initialization
	void Start () 
	{
		rotateWheel = schiffsRad.GetComponent<RotateWheel> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rotateWheel.isRotation == RotateWheel.IsRotation.Left) {
			worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, rotateWheel.getWheelRotationSpeed() / 10.0f * Time.deltaTime);
			//this.transform.Rotate (Vector3.up, rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
		} else if (rotateWheel.isRotation == RotateWheel.IsRotation.Right) {
			worldParent.transform.RotateAround(schiff.transform.position, Vector3.up, -rotateWheel.getWheelRotationSpeed() / 10.0f * Time.deltaTime);
			//this.transform.Rotate (Vector3.up, -rotateWheel.getWheelRotationSpeed() / 2.0f * Time.deltaTime);
		}

		this.transform.Translate(-this.transform.forward * 4.0f * Time.deltaTime);
	}


}
