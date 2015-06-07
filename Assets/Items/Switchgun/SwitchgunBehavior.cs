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

	public GameObject laserPointer;
	public LayerMask layerMask;

	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetFinder) {
			if(Physics.Raycast(transform.position, transform.forward, out hit, 500.0f, layerMask))
			{
				//print("raycast hit");
				targetItem = hit.collider.gameObject;
				
				if(targetItem.tag == "Item" && targetItem.GetComponent<MeshRenderer>() != null)
				{
					newTargetId = targetItem;

					if(targetId != null)
					{
						if(targetId.Equals(newTargetId) )
						{
							targetId.GetComponent<MeshRenderer>().material = Resources.Load("Highlighted") as Material;
						}
						else 
						{
							targetId.GetComponent<MeshRenderer>().material = baseColor;
							baseColor = newTargetId.GetComponent<MeshRenderer>().material;
						}
					}
					if(newTargetId != null && targetId == null)
					{
						baseColor = newTargetId.GetComponent<MeshRenderer>().material;
					}

					targetId = newTargetId;
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
		if(Physics.Raycast(transform.position, transform.forward, out hit, 500.0f, layerMask))
		{
			targetItem = hit.collider.gameObject;
			
			if(targetItem.tag == "Item")
			{
				targetLocation = targetItem.transform.position;

				playerLocation = player.transform.position;
				player.transform.position = targetLocation;
				playerLocation.y += 0.5f;
				targetItem.transform.position = playerLocation;
				foreach(Controls controls in player.GetComponents<Controls>())
				{
					if(!controls.hydraActive)
					{
						controls.unGrabWorld();
					}
				}
			}
		}
	}
	public void Reload(){}
	public void OnEquip(){
		targetFinder = true;
		laserPointer.SetActive (true);
		player = this.transform.root.FindChild ("Blobb").gameObject;
		print (player.name);
	}
	public void OnDeequip(){
		targetFinder = false;
		laserPointer.SetActive (false);
		if (targetId != null) {
			targetId.GetComponent<MeshRenderer>().material = baseColor;
		}

	}
	public string getType(){
		return "gun";
	}
}
