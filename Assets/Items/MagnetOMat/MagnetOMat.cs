using UnityEngine;
using System.Collections;

public class MagnetOMat : MonoBehaviour,Item 
{
	public GameObject magnet;

	GameObject currentItem;
	GameObject currentItemId;
	GameObject newItemId;
	Rigidbody itemRigid;

	bool hasItem = false;
	bool pullingItem = false;

	public GameObject laserPointer;

	RaycastHit hit_Target;
	Material baseColor;

	void Update()
	{
		if (pullingItem) {
			Vector3 directionToGun = magnet.transform.position + (transform.forward * 0.3f) - currentItem.transform.position;
			itemRigid.AddForce (directionToGun * 100);
			itemRigid.velocity = new Vector3 (Mathf.Clamp (itemRigid.velocity.x, 0.0f, 10.0f), Mathf.Clamp (itemRigid.velocity.y, 0.0f, 10.0f), Mathf.Clamp (itemRigid.velocity.z, 0.0f, 10.0f));
//			Debug.Log (itemRigid.velocity);
		} 
		else 
		{
		
			if(Physics.Raycast(magnet.transform.position, transform.forward, out hit_Target, 500.0f))
			{
				//Debug.DrawLine(magnet.transform.position, hit_Target.point);
				//print (hit_Target.collider.name);
				currentItem = hit_Target.collider.gameObject;
				
				if(currentItem.tag == "Item" && currentItem.GetComponent<MeshRenderer>() != null)
				{
					newItemId = currentItem;
					
					if(currentItemId != null)
					{
						if(currentItemId.Equals(newItemId) )
						{
							currentItemId.GetComponent<MeshRenderer>().material = Resources.Load("Highlighted_Magnet") as Material;
							//targetId.GetComponent<MeshRenderer>().material.SetFloat("_EmissionColor", 0.5f);
						}
						else 
						{
							currentItemId.GetComponent<MeshRenderer>().material = baseColor;
							baseColor = newItemId.GetComponent<MeshRenderer>().material;
							
							//.SetColor("_EmissionColor",baseColor);
							//targetId.GetComponent<MeshRenderer>().material.SetFloat("_EmissionColor", 0.0f);
							
						}
					}
					if(newItemId != null && currentItemId == null)
					{
						baseColor = newItemId.GetComponent<MeshRenderer>().material;
					}
					
					currentItemId = newItemId;
					
					//targetLocation = targetItem.transform.position;
					//playerLocation = transform.root.position;
					//transform.root.position = targetLocation;
					//targetItem.transform.position = playerLocation;
				}
				else
				{
					if(currentItemId != null)
					{
						currentItemId.GetComponent<MeshRenderer>().material = baseColor;
					}
					
				}
			}
		}
		
		//Debug.DrawLine(magnet.transform.position, magnet.transform.position + transform.forward);
	}

	public void UseOnce()
	{
		if(!hasItem)
		{
			RaycastHit hit;
			if(Physics.Raycast(magnet.transform.position, transform.forward ,out hit))
			{
				currentItem = hit.collider.gameObject;

				if(currentItem.tag == "Item")
				{
					print (currentItem.name + "picked Up");
					itemRigid = currentItem.GetComponent<Rigidbody>();
					hasItem = true;
					pullingItem = true;

					currentItemId.GetComponent<MeshRenderer>().material = baseColor;
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
