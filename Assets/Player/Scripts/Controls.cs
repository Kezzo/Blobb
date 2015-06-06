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
	MeshRenderer grabIndicator;

	Vector3 previousHandPosition =  Vector3.zero;
	Vector3 controllerPosition;

	public bool itemInTrigger{get; set;}
	public GameObject item{get; set;}
	public bool itemIsInHand{get; set;}
	Collider itemCollider;
	Rigidbody itemRigid;
	Item itemClass;

	public bool usableWorldInTrigger{ get; set;}
	bool grabbedWorldObject;

	private ConfigurableJoint configJoint;
	private WorldTrigger targetGrab;
	private Rigidbody targetRigid;
	JointDrive jDrive = new JointDrive();

	public InventoryHandler inventory;
	bool itemIsUsable;
	// will always be set to parent prior to picking the item up
	Transform itemParent;

	public LayerMask layerMaskForUnderWorldCheck;

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

		jDrive.positionSpring = 5000.0f;
		jDrive.maximumForce = Mathf.Infinity;

		handCollider = hand.GetComponents<SphereCollider>()[0];

		grabIndicator = target.GetChild (0).GetComponent<MeshRenderer> ();

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

		if (grabbedWorldObject) {
			MoveWorldObject();
		}

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
			else if(targetGrab.worldTrigger || (targetGrab.worldTrigger && targetGrab.playerTrigger && !itemInTrigger))
			{
				GrabWorld(true);
			}
			else if(usableWorldInTrigger)
			{
				grabbedWorldObject = true;
			}
		}
		else if(hydra.GetButtonUp(SixenseButtons.TRIGGER))
		{
			if(itemIsInHand)
			{
				ThrowOrStoreItem();
			}
			else
			{
				GrabWorld(false);
			}

			grabbedWorldObject = false;
		}

		if(itemIsInHand)
		{
			if(hydra.GetButtonDown(SixenseButtons.BUMPER))
			{
				if(itemIsUsable)
				{
					itemClass.UseOnce();
				}
			}
			
			if(hydra.GetButtonDown(SixenseButtons.ONE))
			{
				if(itemIsUsable)
				{
					itemClass.Reload();
				}
			}
		}
	}

	void MoveWorldObject()
	{
		if (item != null) {
			Vector3 relativePos = hand.transform.position - item.transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
			item.transform.localEulerAngles = new Vector3(item.transform.rotation.x, rotation.eulerAngles.y, item.transform.rotation.z);
		}
	}

	void MoveHands()
	{
		controllerPosition = new Vector3(hydra.Position.x * Sensitivity.x,
		                                 hydra.Position.y * Sensitivity.y,
		                                 hydra.Position.z * Sensitivity.z );

		if (hydra.GetButtonDown (SixenseButtons.START)) {

			controllerOffsetY = Mathf.Abs(controllerPosition.y - 1.0f);

			controllerOffsetZ = Mathf.Abs(controllerPosition.z - 2.5f);
		}

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
		//print ("GrabItem() called!");
		//print (item.name+" grabbed!");
		itemClass = item.GetComponent<Item>();
		itemRigid = item.GetComponent<Rigidbody>();
		itemRigid.isKinematic = true;
		if(itemRigid.isKinematic)
		{
			if(item.layer == 14)
			{
				itemIsUsable = true;
				itemClass.OnEquip();
				item.transform.rotation = target.transform.rotation;
			}
			else
			{
				itemIsUsable = false;
			}

			if(inventory.isItemStoredInInventory(item))
			{
				itemParent = inventory.getParentFromItem(item);
			}
			else
			{
				if(item.transform.parent != null)
				{
					if(!item.transform.parent.Equals(hand.transform) || !item.transform.parent.name.Contains("unterarm"))
					{
						itemParent = item.transform.parent;
					}
				}


			}

			item.transform.parent = hand.transform;
			item.transform.localPosition = new Vector3(-0.5f,0,0);

			itemIsInHand = true;
			item.layer = 13;
		}
	}

	void ThrowOrStoreItem()
	{
		Vector3 resultingDirection = (hand.transform.position - previousHandPosition);
		float maxThrowForce = Mathf.Abs(Mathf.Max(resultingDirection.x, resultingDirection.y, resultingDirection.z)) * 10.0f;

		//Debug.Log(maxThrowForce);

		if(inventory.isItemTouchingInventory(item.gameObject) && maxThrowForce < 0.1f)
		{
			inventory.storeItem(item, itemIsUsable, itemParent);
		}
		else
		{
			//print ("ThrowItem() called!");
			itemRigid = item.GetComponent<Rigidbody>();
			itemRigid.isKinematic = false;
			if(itemRigid.IsSleeping())
			{
				itemRigid.WakeUp();
			}

			itemRigid.AddForce(resultingDirection * 100.0f,ForceMode.VelocityChange);
			
			item.GetComponent<Collider>().isTrigger = false;

			if(itemParent != null)
			{
				if(!itemParent.Equals(hand.transform) || !item.transform.parent.name.Contains("unterarm"))
				{
					//				print("Parent ist not hand");
					item.transform.parent = itemParent;
				}
			}
			else
			{
				item.transform.parent =  null;
			}


			if (itemIsUsable)
			{
				item.layer = 14;
			}
			else
			{ 
				item.layer = 9;
			}
			CheckItemUnderWorld();
		}

		if(itemIsUsable)
		{
			itemClass.OnDeequip();
			itemClass = null;
		}
		
		item = null;
		itemIsInHand = false;
		itemIsUsable = false;
	}

	void GrabWorld(bool activateGrab)
	{
		//print ("GrabWorld() called!");
		if(activateGrab)
		{
			//print("Grabbed World!");
			hydraActive = false;
			targetRigid.constraints = RigidbodyConstraints.FreezePosition;
			handCollider.enabled = false;
			//Vector3 worldPosition = transform.TransformPoint(target.transform.position);
			Vector3 worldPosition = target.transform.position;
			target.transform.parent = null;
			target.transform.position = worldPosition;

			grabIndicator.enabled = true;
		}
		else
		{
			//print("Ungrabbed World!");
			target.transform.parent = targets;
			hydraActive = true;
			
			jDrive.mode = JointDriveMode.None;
			
			configJoint.xDrive = jDrive;
			configJoint.yDrive = jDrive;
			configJoint.zDrive = jDrive;
			handCollider.enabled = true;

			grabIndicator.enabled = false;
		}
	}



	//After we ungrab an item, to check if item under the world, if then teleport over world
	void CheckItemUnderWorld()
	{
		//print ("CheckItemUnderWorld() called!");
		RaycastHit hitDown;
		if(!Physics.Raycast(item.transform.position, Vector3.down, out hitDown, 100.0f))
		{
			item.transform.position = new Vector3(item.transform.position.x,1.0f, item.transform.position.z);
		}
	}
}
