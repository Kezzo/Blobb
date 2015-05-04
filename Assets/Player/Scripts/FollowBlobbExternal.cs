using UnityEngine;
using System.Collections;

public class FollowBlobbExternal : MonoBehaviour {

	public GameObject blobb;
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = blobb.transform.position;
		this.transform.rotation = blobb.transform.rotation;
	}
}
