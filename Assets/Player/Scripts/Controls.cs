using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	SixenseInput.Controller hydra;
	public bool isRightHydra;
	public GameObject hand;
	SphereCollider handCollider;

	public float controllerOffsetY = 1.5f;
	public float controllerOffsetZ = 1.5f;
	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );
	public bool hydraActive = true;

	public Transform target;
	public Transform targets;

	Vector3 previousHandPosition =  Vector3.zero;
	Vector3 controllerPosition;

	public bool itemInTrigger{get; set;}
	public GameObject item{get; set;}
	public bool itemIsInHand{get; set;}
	Collider itemCollider;
	Rigidbody itemRigid;

	private ConfigurableJoint configJoint;
	private WorldTrigger targetGrab;
	private Rigidbody targetRigid;
	JointDrive jDrive = new JointDrive();

	public InventoryHandler inventory;
	bool itemIsUsable;

	void Awake()
	{
		targetGrab = target.GetComponent<WorldTrigger>();
		if(isRightHydra)
		{
			configJoint = this.GetComponents<ConfigurableJoint>()[0];
		}
		else
		{
			configJoint = this.GetComponents<ConfigurableJoint>()[1];
		}
		targetRigid = target.GetComponent<Rigidbody>();

		//rigid = this.GetComponent<Rigidbody>();

		jDrive.positionSpring = 500.0f;
		jDrive.maximumForce = Mathf.Infinity;

		handCollider = hand.GetComponents<SphereCollider>()[0];

	}

	void Update () 
	{
		// Restrict rotation around Y-Axis
		this.transform.eulerAngles = new Vector3(0.0f,this.transform.eulerAngles.y,0.0f);

		if(isRightHydra)
		{
			hydra = SixenseInput.Controllers[1];
		}
		else
		{
			hydra = SixenseInput.Controllers[0];
		}

		MoveHands();
		CheckWhichGrab();

		previousHandPosition = hand.transform.position;
	}

	void CheckWhichGrab()
	{
		if(hydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			if(itemInTrigger && item != null)
			{
				GrabItem();
			}
			else if(targetGrab.worldTrigger)
			{
				GrabWorld(true);
			}
		}
		else if(hydra.GetButtonUp(SixenseButtons.TRIGGER))
		{
			if(itemIsInHand)
			{
				if(inventory.isItemInInventory(item.gameObject))
				{
					if(itemIsUsable)
					{
						inventory.storeItem(item, true);
					}
					else
					{
						inventory.storeItem(item, false);
					}

					item = null;
					itemIsInHand = false;
				}
				else
				{
					ThrowItem();
				}

			}
			else
			{
				GrabWorld(false);
			}
		}

		if(hydra.GetButtonDown(SixenseButtons.BUMPER))
		{
			if(itemIsUsable)
			{
				item.GetComponent<Item>().UseOnce();
			}
		}

		if(hydra.GetButtonDown(SixenseButtons.ONE))
		{
			if(itemIsUsable)
			{
				item.GetComponent<Item>().Reload();
			}
		}
	}

	void MoveHands()
	{
		controllerPosition = new Vector3(hydra.Position.x * Sensitivity.x,
		                                 hydra.Position.y * Sensitivity.y,
		                                 hydra.Position.z * Sensitivity.z );
		controllerPosition.y -= controllerOffsetY;
		controllerPosition.z += controllerOffsetZ;
		
		if(hydraActive)
		{
			target.transform.localPosition = controllerPosition;
			target.transform.localRotation = hydra.Rotation;
		}
		else
		{
			configJoint.targetPosition = controllerPosition;
			jDrive.mode = JointDriveMode.Position;
			
			configJoint.xDrive = jDrive;
			configJoint.yDrive = jDrive;
			configJoint.zDrive = jDrive;
		}
	}

	void GrabItem()
	{
		print ("GrabItem() called!");
		//print (item.name+" grabbed!");
		itemRigid = item.GetComponent<Rigidbody>();
		itemRigid.isKinematic = true;
		if(itemRigid.isKinematic)
		{
			if(item.layer == 14)
			{
				itemIsUsable = true;
				item.transform.rotation = target.transform.rotation;
			}
			else
			{
				itemIsUsable = false;
			}
			item.transform.parent = hand.transform;
			item.transform.localPosition = new Vector3(-0.5f,0,0);

			itemIsInHand = true;
			item.layer = 13;
		}
	}

	void ThrowItem()
	{
		print ("ThrowItem() called!");
		itemRigid = item.GetComponent<Rigidbody>();
		itemRigid.isKinematic = false;
		if(itemRigid.IsSleeping())
		{
			itemRigid.WakeUp();
		}
		
		Vector3 resultingForce = (hand.transform.position - previousHandPosition);
		itemRigid.AddForce(resultingForce * 3000.0f,ForceMode.Acceleration);

		item.GetComponent<Collider>().isTrigger = false;

		hand.transform.DetachChildren();
		item.transform.parent = null;
		if (itemIsUsable)
		{
			item.layer = 14;
		}
		else
		{ 
			item.layer = 9;
		}
		CheckItemUnderWorld();
		item = null;
		itemIsInHand = false;
		itemIsUsable = false;
	}

	void GrabWorld(bool activateGrab)
	{
		print ("GrabWorld() called!");
		if(activateGrab)
		{
			print("Grabbed World!");
			hydraActive = false;
			targetRigid.constraints = RigidbodyConstraints.FreezePosition;
			handCollider.enabled = false;
			//Vector3 worldPosition = transform.TransformPoint(target.transform.position);
			Vector3 worldPosition = target.transform.position;
			target.transform.parent = null;
			target.transform.position = worldPosition;
		}
		else
		{
			print("Ungrabbed World!");
			target.transform.parent = targets;
			hydraActive = true;
			
			jDrive.mode = JointDriveMode.None;
			
			configJoint.xDrive = jDrive;
			configJoint.yDrive = jDrive;
			configJoint.zDrive = jDrive;
			handCollider.enabled = true;
		}
	}

	void LateUpdate()
	{
		//allow the Tentacles to follow their Targets, i.e stretching
		hand.transform.position = target.transform.position;
	}

	//After we ungrab an item, to check if item under the world, if then teleport over world
	void CheckItemUnderWorld()
	{
		print ("CheckItemUnderWorld() called!");
		RaycastHit hitDown;
		if(!Physics.Raycast(item.transform.position, Vector3.down, out hitDown))
		{
			RaycastHit hitUp;
			if(Physics.Raycast(item.transform.position, Vector3.up, out hitUp))
			{
				print (hitUp.point);
				Vector3 newPosition = hitUp.point;
				MeshRenderer mesh = item.GetComponent<MeshRenderer>();
				newPosition.y += Mathf.Max(new float[]{mesh.bounds.size.x, mesh.bounds.size.y, mesh.bounds.size.z})+2.0f;
				item.transform.position = newPosition;
			}
		}
	}
}
