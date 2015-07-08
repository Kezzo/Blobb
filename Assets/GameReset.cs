using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevelAsync("Menu");
		}

	}
}
