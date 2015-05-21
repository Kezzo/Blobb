using UnityEngine;
using System.Collections;

public class AugeIK : MonoBehaviour {

	public Transform centerEye;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offsetRotation = centerEye.rotation.eulerAngles;
		offsetRotation.x -= 90.0f;
		this.transform.rotation = Quaternion.Euler(offsetRotation);

	
	}
}
