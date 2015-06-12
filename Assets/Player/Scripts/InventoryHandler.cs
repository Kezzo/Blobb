using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryHandler : MonoBehaviour {

	//public GameObject inventory;

	List<ItemParentSave> itemInInventory = new List<ItemParentSave>();
	List<GameObject> itemInInventoryTrigger = new List<GameObject>();
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
			//print(other.name + " entered Inventory Trigger");
			itemInInventoryTrigger.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.layer == 13)
		{
			//print(other.name + " left Inventory Trigger");
			foreach(GameObject item in itemInInventoryTrigger.ToArray())
			{
				if(other.gameObject.Equals(item))
				{
					itemInInventoryTrigger.Remove(item);
				}
			}
		}
	}

	public void storeItem(GameObject itemToStore, bool isUsable, Transform parent)
	{
		itemInInventory.Add(new ItemParentSave(itemToStore, parent));
		itemToStore.transform.parent = this.transform;

		Collider[] colliders = itemToStore.GetComponents<Collider>();
		for(int i=0; i<colliders.Length; i++)
		{
			colliders[i].isTrigger = true;
		}

		if(isUsable)
		{
			itemToStore.layer = 14;
		}
		else
		{
			itemToStore.layer = 9;
		}		
	}

	public bool isItemTouchingInventory(GameObject itemToCheck)
	{
		foreach(GameObject item in itemInInventoryTrigger)
		{
			if(itemToCheck.Equals(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool isItemStoredInInventory(GameObject itemToCheck)
	{
		foreach(ItemParentSave item in itemInInventory)
		{
			if(itemToCheck.Equals(item.ItemGameObject))
			{
				return true;
			}
		}

		return false;
	}

	public Transform getParentFromItem(GameObject itemToCheck)
	{
		foreach(ItemParentSave item in itemInInventory)
		{
			if(itemToCheck.Equals(item.ItemGameObject))
			{
				return item.parent;
			}
		}

		return null;
	}
	
}
