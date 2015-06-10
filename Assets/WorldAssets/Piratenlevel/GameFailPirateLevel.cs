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
//		print (other.name);
		if (other.name.Contains ("Piratenschiff") && other.name.Contains ("Collider")) {
			other.transform.root.GetComponent<Schiffssteuerung>().setMovement(false);
			//TODO: reset Level!

			StartCoroutine(ResetLevelAfter(3.0f));

		}

	}

	public IEnumerator ResetLevelAfter(float secondsToWait)
	{
		//print ("IEnumerator started!");
		yield return new WaitForSeconds(secondsToWait);
		//print("Explode!");
		Application.LoadLevel(Application.loadedLevelName);
	}
}
