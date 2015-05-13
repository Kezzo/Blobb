using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryHandler : MonoBehaviour {

	//public GameObject inventory;


	List<GameObject> itemInInventory = new List<GameObject>();
	//GameObject[] itemsInInvetory = new GameObject[];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 13)
		{
			print(other.name + " entered Inventory Trigger");
			itemInInventory.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.layer == 13)
		{
			print(other.name + " left Inventory Trigger");
			foreach(GameObject item in itemInInventory.ToArray())
			{
				if(other.gameObject.Equals(item))
				{
					itemInInventory.Remove(item);
				}
			}
		}
	}

	public void storeItem(GameObject itemToStore, bool isUsable)
	{
		itemToStore.transform.parent = this.transform;
		itemToStore.GetComponent<Collider>().isTrigger = true;
		if(isUsable)
		{
			itemToStore.layer = 14;
		}
		else
		{
			itemToStore.layer = 9;
		}


	}

	public bool isItemInInventory(GameObject itemToCheck)
	{
		foreach(GameObject item in itemInInventory.ToArray())
		{
			if(itemToCheck.Equals(item))
			{
				return true;
			}
		}
		return false;
	}
	
}
