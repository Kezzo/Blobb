using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {

	private bool positioned = false;

	void Update()
	{
		if(GameObject.Find("Player") != null && !positioned)
		{
			GameObject player = GameObject.Find("Player");
			//print ("Player found");
			player.transform.position = this.transform.position;
			player.transform.rotation = this.transform.rotation;

			positioned = true;
		}
	}
}
