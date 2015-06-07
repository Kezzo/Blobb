using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {

	bool parenting = false;

	void Start()
	{

	}

	void Update()
	{
		if(GameObject.Find("Player") != null)
		{
			GameObject player = GameObject.Find("Player");
			print ("Player found");
			player.transform.position = this.transform.position;
			player.transform.rotation = this.transform.rotation;
			if(transform != null && !parenting)
			{
				player.transform.SetParent(this.transform);
				parenting = true;
				//GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.parent = this.transform;
			}
		}
	}
}
