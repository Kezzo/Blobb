using UnityEngine;
using System.Collections;

public class Schiffssteuerung : MonoBehaviour {

	public GameObject schiffsRad;
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
			this.transform.Rotate (Vector3.up, 8.0f * Time.deltaTime);
		} else if (rotateWheel.isRotation == RotateWheel.IsRotation.Right) {
			this.transform.Rotate (Vector3.up, -8.0f * Time.deltaTime);
		}
//		print (schiffsRad.transform.localEulerAngles.y);
		//this.transform.rotation = Quaternion.Euler(new Vector3 (this.transform.rotation.x, schiffsRad.transform.localEulerAngles.y , this.transform.rotation.z));
	}


}
