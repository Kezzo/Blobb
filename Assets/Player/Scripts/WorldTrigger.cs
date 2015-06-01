using UnityEngine;
using System.Collections;

public class WorldTrigger : MonoBehaviour {

	public bool worldTrigger{get; set;}
	public bool playerTrigger{get; set;}
	
	void OnTriggerStay(Collider info)
	{
		//print ("TriggerEnter "+info.tag+" "+info.name);
		
		if(info.tag == "World")
		{
			worldTrigger = true;
		}
		else
		{
			worldTrigger = false;
		}

		if(info.tag == "Player")
		{
			playerTrigger = true;
		}
		else
		{
			playerTrigger = false;
		}
		
	}
	
	void OnTriggerExit(Collider info)
	{
		//print ("TriggerExit"+info.tag);
		if(info.tag == "World")
		{
			worldTrigger = false;
		}

		if(info.tag == "Player")
		{
			playerTrigger = false;
		}
	}
}
