using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {

	public bool moveUpAndDown;
	bool goBack;
	Rigidbody rigid;
	bool wasHit;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!wasHit)
		{
			if(moveUpAndDown)
			{
				if(goBack)
				{
					this.transform.Translate(Vector3.right * Time.deltaTime);
				}
				else
				{
					this.transform.Translate(Vector3.left * Time.deltaTime);
				}
				
			}
			else
			{
				if(goBack)
				{
					this.transform.Translate(Vector3.up * Time.deltaTime);
				}
				else
				{
					this.transform.Translate(Vector3.down * Time.deltaTime);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Targets"))
		{
			goBack = !goBack;
		}
	}

	void OnCollisionEnter(Collision collsion)
	{
		if(collsion.collider.tag == "Item")
		{
			wasHit = true;
			rigid.useGravity = true;
		}

		//Debug.Log(collsion.collider.name);
	}
}
