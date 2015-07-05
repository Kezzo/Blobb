using UnityEngine;
using System.Collections;

public class Lore : MonoBehaviour {

	//Transform rift;
	bool movingForward = true;
	
	void Update () 
	{
		if(movingForward)
		{
			this.transform.Translate(Vector3.down * 2 * Time.deltaTime);
		}

		this.transform.Translate(Vector3.right *Time.deltaTime * 15.0f * Input.GetAxis("Horizontal")/8.0f);
		/*
		if(rift.transform.localEulerAngles.z > 180.0f)
		{
			this.transform.Translate(Vector3.right *Time.deltaTime * 20.0f * (1.0f - rift.transform.localEulerAngles.z/360));
		}
		else if(rift.transform.localEulerAngles.z > 0.0f)
		{
			this.transform.Translate(Vector3.left * Time.deltaTime * 20.0f * rift.transform.localEulerAngles.z/360.0f);
		}
		*/
	}

	void OnCollisionEnter(Collision info)
	{
		if(info.collider.gameObject.tag == "Player")
		{
			info.collider.transform.parent.parent = this.transform;
			//rift = GameObject.Find("CenterEyeAnchor").transform;
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "stopper")
		{
			movingForward = false;
			this.gameObject.tag = "World";
			this.gameObject.layer = 11;
		}
	}
}
