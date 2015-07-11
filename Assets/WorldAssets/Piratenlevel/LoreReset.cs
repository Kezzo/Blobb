using UnityEngine;
using System.Collections;

public class LoreReset : MonoBehaviour {

	public Transform resetPosition;

	Lore lorenControls;

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("boat"))
		{
			other.transform.position = resetPosition.position;
			if(lorenControls == null)
			{
				lorenControls = other.GetComponent<Lore>();
			}
			lorenControls.movingForward = false;
			StartCoroutine(startAgainAfter(2.0f));
		}
	}

	public IEnumerator startAgainAfter(float secondsToWait)
	{
		print ("startAgain");
		yield return new WaitForSeconds(secondsToWait);
		print ("started");
		lorenControls.movingForward = true;
	}
}
