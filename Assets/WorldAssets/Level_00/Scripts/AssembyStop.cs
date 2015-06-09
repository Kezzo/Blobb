using UnityEngine;
using System.Collections;

public class AssembyStop : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider enter)
	{
		if (enter.CompareTag ("Mover")) {

			enter.transform.SendMessage("stopMoving", SendMessageOptions.DontRequireReceiver);

		}


	}
}
