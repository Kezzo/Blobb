using UnityEngine;
using System.Collections;

public class PassageChange : MonoBehaviour {

	public bool statuePassaging = false;
	public bool staging = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(statuePassaging && staging)
		{
			this.transform.position = new Vector3(-0.03f, 7.46f, 29.83f);
			staging = false;
		}
	}

	void returnHub()
	{
		statuePassaging = true;
	}
}
