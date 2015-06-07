using UnityEngine;
using System.Collections;

public class GameFailPirateLevel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		if (other.name.Contains ("piratenschiff")) {
			this.transform.root.GetComponent<Schiffssteuerung>().setMovement(false);
			//TODO: reset Level!
		}

	}
}
