using UnityEngine;
using System.Collections;

public class BallActivation : MonoBehaviour {

	public GameObject lightshowSpawner;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider objectCollider)
	{
		//if Raycast Hit...
		/*if(objectCollider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
				lightshowSpawner.BroadcastMessage("SetActiveStatus", true, SendMessageOptions.DontRequireReceiver);
		}*/
	}
}