using UnityEngine;
using System.Collections;

public class DunkelkammerReset : MonoBehaviour {

	public bool destroy = false;
	public GameObject lightshowSpawner;

	// Update is called once per frame
	void Update () {
		if(destroy == true)
		{
			lightshowSpawner.BroadcastMessage("SelfDestruct", SendMessageOptions.DontRequireReceiver);
			lightshowSpawner.SendMessage("BuildingSphereField", SendMessageOptions.DontRequireReceiver);
			destroy = false;
		}
	}

	void OnTriggerEnter(Collider objectCollider)
	{
		if(objectCollider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			destroy = true;
		}
	}
}
