using UnityEngine;
using System.Collections;

public class SwitchgunBehavior : MonoBehaviour, Item {

	private GameObject targetItem;
	private Vector3 targetLocation;
	private Vector3 playerLocation;
	private RaycastHit hit;
	private bool targetFinder = false;
	private Material baseColor;
	private GameObject targetId;
	private GameObject newTargetId;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetFinder) {
			if(Physics.Raycast(transform.position, transform.forward, out hit, 500.0f))
			{
				targetItem = hit.collider.gameObject;
				
				if(targetItem.tag == "Item")
				{
					newTargetId = targetItem;

					if(targetId != null)
					{
						if(targetId.Equals(newTargetId) )
						{
							targetId.GetComponent<MeshRenderer>().material = Resources.Load("Highlighted") as Material;
							//targetId.GetComponent<MeshRenderer>().material.SetFloat("_EmissionColor", 0.5f);
						}else 
						{
							targetId.GetComponent<MeshRenderer>().material = baseColor;
							baseColor = newTargetId.GetComponent<MeshRenderer>().material;//.SetColor("_EmissionColor",baseColor);
							//targetId.GetComponent<MeshRenderer>().material.SetFloat("_EmissionColor", 0.0f);

						}
					}
					if(newTargetId != null && targetId == null)
					{
						baseColor = newTargetId.GetComponent<MeshRenderer>().material;
					}

					targetId = newTargetId;

					//targetLocation = targetItem.transform.position;
					//playerLocation = transform.root.position;
					//transform.root.position = targetLocation;
					//targetItem.transform.position = playerLocation;
				}
				else
				{
					if(targetId != null)
					{
						targetId.GetComponent<MeshRenderer>().material = baseColor;
					}

				}
			}
		}
	}
	public void UseOnce(){
		if(Physics.Raycast(transform.position, transform.forward, out hit, 500.0f))
		{
			targetItem = hit.collider.gameObject;
			
			if(targetItem.tag == "Item")
			{
				targetLocation = targetItem.transform.position;
				playerLocation = transform.root.position;
				transform.root.position = targetLocation;
				targetItem.transform.position = playerLocation;
			}
		}
	}
	public void Reload(){}
	public void OnEquip(){
		targetFinder = true;
	}
	public void OnDeequip(){
		targetFinder = false;
	}
	public string getType(){
		return "gun";
	}
}
