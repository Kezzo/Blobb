using UnityEngine;
using System.Collections;

public class SwitchGameObjectsToLayer : MonoBehaviour {

	public string[] tags;
	public int switchToLayer;
	public string ignoreWhenNameContains;

	void OnTriggerEnter(Collider other)
	{
//		print ("OnTriggerEnter: "+other.name);
		bool hasSupportedTag = false;
		//print(other.name);
		foreach(string tag in tags)
		{
			if(other.tag == tag)
			{
				hasSupportedTag = true;
			}
		}

		if(hasSupportedTag && !other.name.Contains(ignoreWhenNameContains))
		{
			other.gameObject.layer = 15;
			//print ("Moved "+other.name+" to Layer 15!");
		}
	}
}
