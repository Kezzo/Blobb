using UnityEngine;
using System.Collections;

public class FollowTargets : MonoBehaviour {

	public float yPositionOnCollision = 0.0f;
	public GameObject targetToFollow;
	WorldTrigger worldTrigger;

	bool targetInGround;

	void Start()
	{
		worldTrigger = targetToFollow.GetComponent<WorldTrigger>();
	}

	void Update()
	{
		if(worldTrigger.worldInTrigger)
		{
			print ("Under Ground!");
			this.transform.position = new Vector3(targetToFollow.transform.position.x, yPositionOnCollision,targetToFollow.transform.position.z);
		}
		else
		{
			print ("NOT Under Ground!");
			this.transform.position = targetToFollow.transform.position;
		}

	}

	void OnCollisionEnter(Collision collision)
	{
		//print ("Collision");
		if(collision.collider.tag == "World")
		{
			if(collision.contacts[0].normal.y > 0.0f && !targetInGround)
			{
				//print ("Ground Collision");
				yPositionOnCollision = this.transform.position.y;
				targetInGround = true;
			}

		}
	}

	void OnCollisionExit(Collision collision)
	{
		if(collision.collider.tag == "World" && targetInGround)
		{
			yPositionOnCollision = 0.0f;
			targetInGround = false;
		}
	}

	void LateUpdate()
	{

	}
}
