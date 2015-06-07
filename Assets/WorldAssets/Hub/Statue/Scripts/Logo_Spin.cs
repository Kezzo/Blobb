using UnityEngine;
using System.Collections;

public class Logo_Spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, Vector3.down, Time.deltaTime*50.0f);
	}
}
