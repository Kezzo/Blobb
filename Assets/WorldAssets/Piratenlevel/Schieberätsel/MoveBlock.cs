using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	SixenseInput.Controller hydra;

	float step = 0.2f;
	bool pushBlock = true;
	void Start () {

	}

	void Update () {
		hydra = SixenseInput.Controllers[1];
	}
	void OnTriggerEnter (Collider objectCollider)
	{
		if ((objectCollider.name == "unterarm_l" && pushBlock) || (objectCollider.name == "unterarm_r" && pushBlock))
		{
			float whereX = Mathf.Abs (objectCollider.transform.position.x - transform.position.x);
			float whereZ = Mathf.Abs (objectCollider.transform.position.z - transform.position.z);
			if (whereX < whereZ)
			{	

				if(objectCollider.transform.position.z < transform.position.z)
				{
					transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, 3), step);
				}else if (objectCollider.transform.position.z > transform.position.z)
				{
					transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, -3), step);
				}
			}else if ( whereX > whereZ)
			{
				if(objectCollider.transform.position.x < transform.position.x)
				{
					transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(3, 0, 0), step);
				}else if (objectCollider.transform.position.x > transform.position.x)
				{
					transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-3, 0, 0), step);
				}
			}
		}
		if (objectCollider.name == "stuckBlock") 
		{
			pushBlock = false;
			this.GetComponent<Rigidbody>().isKinematic = true;
		}

	}
}
