using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			GameObject.Find("Player").transform.parent = null;
			Application.LoadLevel(Application.loadedLevel);
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameObject.Find("Player").transform.parent = null;
			Application.LoadLevelAsync("Menu");
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			OVRManager.display.RecenterPose();
		}

	}
}
