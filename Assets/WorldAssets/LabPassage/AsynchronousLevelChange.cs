using UnityEngine;
using System.Collections;

public class AsynchronousLevelChange : MonoBehaviour {

	public string levelName;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Application.LoadLevelAsync(levelName);
		}
	}
}
