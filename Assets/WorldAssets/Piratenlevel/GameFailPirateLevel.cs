using UnityEngine;
using System.Collections;

public class GameFailPirateLevel : MonoBehaviour {

	GameObject player;

	public bool shouldCollideWithTerrain;

	public RotateWheel rotateWheel;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains ("Terrain") || other.name.Contains ("wrack") || other.name.Contains ("Wall")) {
			//print (other.name);
			this.transform.parent.GetComponent<Schiffssteuerung>().setMovement(false);
			rotateWheel.rotatingEnabled = false;
			StartCoroutine(ResetLevelAfter(3.0f));

		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.name == "Blobb" && shouldCollideWithTerrain)
		{
			player.transform.parent = null;
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
