using UnityEngine;
using System.Collections;

public class DunkelkammerReset : MonoBehaviour {

	public bool Destroy = false;
	public GameObject lightshowSpawner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Destroy == true)
		{
			lightshowSpawner.BroadcastMessage("SelfDestruct", SendMessageOptions.DontRequireReceiver);
			lightshowSpawner.SendMessage("BuildingSphereField", SendMessageOptions.DontRequireReceiver);
			Destroy = false;
		}
	}

	void OnTriggerEnter(Collider objectCollider)
	{
		if(objectCollider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			Destroy = true;
		}
	}
}
