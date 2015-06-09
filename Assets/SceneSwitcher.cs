using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel("hub");
		}
		else if(Input.GetKeyDown(KeyCode.V))
		{
			Application.LoadLevel("pirates");
		}
		else if(Input.GetKeyDown(KeyCode.B))
		{
			Application.LoadLevel("switchRätsel");
		}
		else if(Input.GetKeyDown(KeyCode.N))
		{
			Application.LoadLevel("BelowtheDeck");
		}
		else if(Input.GetKeyDown(KeyCode.M))
		{
			Application.LoadLevel("Level_00");
		}
	}
}
