using UnityEngine;
using System.Collections;

public class AsynchronousLevelChange : MonoBehaviour {

	public string levelName;

	void Update()
	{
		if(Input.GetKey(KeyCode.P))
		{
			Application.LoadLevelAsync(levelName);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Application.LoadLevelAsync(levelName);
		}
	}
}
