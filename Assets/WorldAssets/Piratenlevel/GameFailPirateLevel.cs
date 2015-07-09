using UnityEngine;
using System.Collections;

public class GameFailPirateLevel : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.name.Contains ("Terrain") || other.name.Contains ("wrack")) {
			print (other.name);
			this.transform.parent.GetComponent<Schiffssteuerung>().setMovement(false);
			//TODO: reset Level!

			StartCoroutine(ResetLevelAfter(3.0f));

		}

	}

	public IEnumerator ResetLevelAfter(float secondsToWait)
	{
		//print ("IEnumerator started!");
		yield return new WaitForSeconds(secondsToWait);
		//print("Explode!");
		player.transform.parent = null;
		Application.LoadLevel(Application.loadedLevel);
	}
}
