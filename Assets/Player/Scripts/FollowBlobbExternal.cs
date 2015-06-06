using UnityEngine;
using System.Collections;

public class FollowBlobbExternal : MonoBehaviour {

	public float xOffSet,yOffSet,zOffSet;

	public GameObject blobb;
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(blobb.transform.position.x + xOffSet, blobb.transform.position.y + yOffSet, blobb.transform.position.z + zOffSet);
		this.transform.rotation = blobb.transform.rotation;
	}
}
