using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

	public bool worldTrigger{get; set;}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerStay(Collider info)
	{
		//print ("TriggerEnter"+info.tag);

		if(info.tag == "World")
		{
			worldTrigger = true;
		}
		else
		{
			worldTrigger = false;
		}

	}

	void OnTriggerExit(Collider info)
	{
		//print ("TriggerExit"+info.tag);
		if(info.tag == "World")
		{
			worldTrigger = false;
		}
	}
}
