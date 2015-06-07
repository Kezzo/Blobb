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
			print ("Player found");
			GameObject.Find("Player").transform.position = this.transform.position;
			if(transform != null && !parenting)
			{
				GameObject.Find("Player").transform.SetParent(this.transform);
				parenting = true;
				//GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.parent = this.transform;
			}
		}
	}
}
