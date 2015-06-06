using UnityEngine;
using System.Collections;

public class GateOpener : MonoBehaviour {
	public GameObject doorA;
	public GameObject doorB;
	bool open=false;
	bool close=false;
	int opentime=0;
	Vector3 startPosA;
	Vector3 startPosB;

	public bool testmode;

	// Use this for initialization
	void Start () {
	
		if (doorA) {
		
			startPosA=doorA.transform.position;
			startPosB=doorB.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (open == true) {

			if(opentime<50)
			{//print ("Open"+opentime);
				if (doorA) {
					doorA.transform.position += new Vector3(-0.1f,0,0);
					doorB.transform.position += new Vector3(0.1f,0,0);
					
				}

				opentime++;
			}

		
		}


		if (close==true) {
			

				if (doorA) {
					//doorA.transform.position += new Vector3(0.1f,0,0);
					//doorB.transform.position += new Vector3(-0.1f,0,0);
					doorA.transform.position = Vector3.Lerp(doorA.transform.position, startPosA, Time.deltaTime);
					doorB.transform.position = Vector3.Lerp(doorB.transform.position, startPosB, Time.deltaTime);
					
				}
				
				

			
			
		}
	}

	void OnTriggerEnter(Collider enter) {
		if (enter.name.Contains ("container")) {
			open = true;
			close = false;
		}
		//print ("You shall pass!");
		opentime = 0;
	}
	void OnTriggerExit(Collider exit) {
		//print ("You passed!");
		opentime = 0;

		open = false;
		close = true;

	}
}
