using UnityEngine;
using System.Collections;

public class WorldTrigger : MonoBehaviour {

	public bool worldInTrigger{get; set;}
	public bool playerTrigger{get; set;}

	void Update()
	{

	}

	void OnTriggerEnter(Collider info)
	{
		if(info.tag == "World")
		{
			worldInTrigger = true;
		}
		if(info.tag == "Player")
		{
			playerTrigger = true;
		}
	}

	void OnTriggerStay(Collider info)
	{
		if(info.tag == "World")
		{
			worldInTrigger = true;
		}
		else
		{
			//worldInTrigger = false;
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
			worldInTrigger = false;
		}

		if(info.tag == "Player")
		{
			playerTrigger = false;
		}
	}
}
