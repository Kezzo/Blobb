using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

	public bool worldTrigger{get; set;}
	public bool itemTrigger{get; set;}

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
		else if(info.tag == "Item")
		{
			itemTrigger = true;
		}
		else
		{
			worldTrigger = false;
			itemTrigger = false;
		}

	}

	void OnTriggerExit(Collider info)
	{
		print ("TriggerExit"+info.tag);
		if(info.tag == "World")
		{
			worldTrigger = false;
		}
		else if(info.tag == "Item")
		{
			itemTrigger = false;
		}
	}
}
