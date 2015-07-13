using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {
	
	Lore boatScript;
	
	void Start()
	{
		boatScript = GetComponent<Lore>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Terrain")
		{
			boatScript.movingForward = false;
			GameObject.Find("Player").transform.parent = null;
			StartCoroutine(ResetLevelAfter(3.0f));
		}
	}

	public IEnumerator ResetLevelAfter(float secondsToWait)
	{
		//print ("IEnumerator started!");
		yield return new WaitForSeconds(secondsToWait);
		//print("Explode!");
		Application.LoadLevel(Application.loadedLevel);
	}
}
