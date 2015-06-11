using UnityEngine;
using System.Collections;

public class demoThrow : MonoBehaviour {
	 GameObject throwThis;
	bool push=false;
	Rigidbody rb;
	public float direction = -8.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (throwThis) {
			if(push==false){
				throwThis.transform.position = transform.position;
			}

			if(push==true)
			{

				rb.AddForce(new Vector3(direction, 0,0));
				//throwThis=null;
				//rb=null;
			}
		}

	}

	void OnTriggerEnter(Collider enter){
		//enter.gameObject.transform.position;

		if (enter.CompareTag ("Item")) {
			push=false;
			if(throwThis!=enter.gameObject){

				throwThis = enter.gameObject;
				rb=throwThis.GetComponent<Rigidbody>();
			}

			print ("grab");

		} 

	}
	void OnTriggerExit(Collider exit){

		if (exit.CompareTag ("Item"))
		    {}else{

			push=true;
		}
	}



}
