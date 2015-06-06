using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {

	void Start()
	{

	}

	void Update()
	{
		if(GameObject.Find("Player") != null)
		{
			print ("Player found");
			GameObject.Find("GameManager").transform.position = this.transform.position;
			if(transform != null)
			{
				//GameObject.Find("GameManager").transform.parent = this.transform;
			}
		}
	}
}
