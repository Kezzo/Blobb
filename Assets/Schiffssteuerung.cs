using UnityEngine;
using System.Collections;

public class Schiffssteuerung : MonoBehaviour {

	public GameObject schiffsRad;

	float previousSchiffsRadRotation;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rotationDifference = previousSchiffsRadRotation - schiffsRad.transform.localRotation.y;

		//if (Mathf.Abs (rotationDifference) > 0.1f) {
			if(previousSchiffsRadRotation > schiffsRad.transform.localRotation.y)
			{
				print ("rechts");
				//this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 5.0f, this.transform.eulerAngles.z);
			}
			else if(previousSchiffsRadRotation < schiffsRad.transform.localRotation.y)
			{
				print ("links");
				//this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y - 5.0f, this.transform.eulerAngles.z);
			}
	//	}

		previousSchiffsRadRotation = schiffsRad.transform.localRotation.y;
	}
}
