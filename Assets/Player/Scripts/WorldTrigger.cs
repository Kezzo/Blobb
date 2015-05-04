using UnityEngine;
using System.Collections;

public class WorldTrigger : MonoBehaviour {

	public bool worldTrigger{get; set;}
	
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
