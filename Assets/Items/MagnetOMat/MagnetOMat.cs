using UnityEngine;
using System.Collections;

public class MagnetOMat : MonoBehaviour,Item 
{
	public GameObject magnet;

	private GameObject currentItem;
	private Rigidbody itemRigid;

	private bool hasItem = false;
	private bool pullingItem = false;

	public GameObject laserPointer;

	void Update()
	{
		if(pullingItem)
		{
			Vector3 directionToGun = magnet.transform.position + (transform.forward * 0.3f) - currentItem.transform.position;
			itemRigid.AddForce( directionToGun * 100 );
			itemRigid.velocity = new Vector3(Mathf.Clamp(itemRigid.velocity.x, 0.0f, 10.0f), Mathf.Clamp(itemRigid.velocity.y, 0.0f, 10.0f), Mathf.Clamp(itemRigid.velocity.z, 0.0f, 10.0f));
			Debug.Log(itemRigid.velocity);
		}
		
		Debug.DrawLine(magnet.transform.position, magnet.transform.position + transform.forward);
	}

	public void UseOnce()
	{
		if(!hasItem)
		{
			RaycastHit hit;
			if(Physics.Raycast(magnet.transform.position, transform.forward,out hit))
			{
				currentItem = hit.collider.gameObject;

				if(currentItem.tag == "Item")
				{
					print (currentItem.name + "picked Up");
					itemRigid = currentItem.GetComponent<Rigidbody>();
					hasItem = true;
					pullingItem = true;
				}
			}
		}
		/*
		else if(pullingItem && hasItem)
		{
			hasItem = false;
			pullingItem = false;
			currentItem.transform.parent = null;
		}
		*/
		else
		{
			hasItem = false;
			pullingItem = false;
			currentItem.transform.parent = null;
			currentItem.transform.localEulerAngles = Vector3.zero;
			itemRigid.velocity = Vector3.zero;
			//Vector3 directionFromGun = currentItem.transform.position - magnet.transform.position;
			itemRigid.AddForce(transform.forward * 1000);
			
		}
	}

	public void Reload()
	{
	}

	public void OnEquip()
	{
		laserPointer.SetActive(true);
	}
	
	public void OnDeequip()
	{
		laserPointer.SetActive(false);
	}

	public string getType()
	{
		return "GravGun";
	}
}
