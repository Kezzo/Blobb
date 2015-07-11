using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	SixenseInput.Controller hydra;

	public bool grabbingIsEnabled = true;

	public bool isRightHydra;
	public GameObject hand;
	SphereCollider handCollider;

	public float controllerOffsetY = 1.5f;
	public float controllerOffsetZ = 1.5f;
	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );
	bool _hydraActive = true;
	public bool hydraActive
	{
		get
		{
			return _hydraActive;
		}
	}

	public Transform target;
	public Transform targets;


	Vector3 previousItemPosition =  Vector3.zero;
	Vector3 basePosition;
	Vector3 initialPosition;
	bool hydraStop = false;
	Vector3 controllerPosition;

	Rigidbody blobbRigid;
	bool isGrabbingWorld = false;

	public bool itemInTrigger{get; set;}
	public GameObject item{get; set;}
	public bool itemIsInHand{get; set;}
	Collider itemCollider;
	Rigidbody itemRigid;
	Item itemClass;

	private ConfigurableJoint configJoint;
	private WorldTrigger targetGrab;
	private Rigidbody targetRigid;
	JointDrive jDrive = new JointDrive();

	public InventoryHandler inventory;
	bool itemIsUsable;
	// will always be set to parent prior to picking the item up
	Transform itemParent;

	public LayerMask layerMaskForUnderWorldCheck;

	public Transform targetFollower;

	public GameObject keybindUI = null;

	public Material[] grabIndicatorMaterials;
	public MeshRenderer grabIndicator;

	void Awake()
	{
		blobbRigid = this.GetComponent<Rigidbody>();
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

		//grabIndicator = hand.transform.GetChild (0).GetComponentInChildren<MeshRenderer> ();

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
		if(grabbingIsEnabled)
		{
			CheckWhichGrab();
			ProcessGrabIndicator();
		}
		
		if(isGrabbingWorld)
		{
			RotationMode();
		}
		if(itemIsInHand)
		{
			previousItemPosition = item.transform.position;
		}


		if(keybindUI != null)
		{
			ToogleKeyBindUI();
		}
	}

	void CheckWhichGrab()
	{
		if(hydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			//print("targetGrab.worldTrigger"+ targetGrab.worldTrigger);
			if(itemInTrigger && item != null && item.layer != 13)
			{
				GrabItem();
			}
			else if(targetGrab.worldInTrigger || (targetGrab.worldInTrigger && targetGrab.playerTrigger && !itemInTrigger))
			{
				isGrabbingWorld = true;
				GrabWorld(true);
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
				isGrabbingWorld = false;
				GrabWorld(false);
			}
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

	void RotationMode()
	{
		if(hydra.GetButtonDown(SixenseButtons.BUMPER))
		{
			blobbRigid.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
		else if(hydra.GetButtonUp(SixenseButtons.BUMPER))
		{
			blobbRigid.constraints = RigidbodyConstraints.None;
			blobbRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}

	void MoveHands()
	{
		controllerPosition = new Vector3(hydra.Position.x * Sensitivity.x,
		                                 hydra.Position.y * Sensitivity.y - controllerOffsetY,
		                                 hydra.Position.z * Sensitivity.z + controllerOffsetZ );

		if (hydra.GetButtonDown (SixenseButtons.START) && !isGrabbingWorld) 
		{
			hydraStop = !hydraStop;
			basePosition = controllerPosition;

			initialPosition = target.gameObject.transform.localPosition;

		}

		if(!hydraStop)
		{
			if(_hydraActive)
			{
				target.transform.localPosition = controllerPosition - basePosition + initialPosition;
				target.transform.localRotation = hydra.Rotation;
			}
			else
			{
				configJoint.targetPosition = controllerPosition - basePosition + initialPosition;
				jDrive.mode = JointDriveMode.Position;
				
				configJoint.xDrive = jDrive;
				configJoint.yDrive = jDrive;
				configJoint.zDrive = jDrive;
			}
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

			if(item.layer == 14)
			{
				itemClass.OnEquip();
			}

			itemIsInHand = true;
			item.layer = 13;
			grabIndicator.enabled = false;
		}
	}

	void ThrowOrStoreItem()
	{
		Vector3 resultingDirection = (item.transform.position - previousItemPosition);

		// To track if handmovement is quick enough that the player wants to throw
		float maxThrowForce = Mathf.Abs(Mathf.Max(resultingDirection.x, resultingDirection.y, resultingDirection.z)) * 10.0f;

		//Debug.Log(maxThrowForce);

		if(inventory.isItemTouchingInventory(item.gameObject) && maxThrowForce < 0.2f)
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
			itemRigid.AddForce(resultingDirection * 1/Time.deltaTime * 1.4f,ForceMode.VelocityChange);
			/*
			if(maxThrowForce < .3f)
			{
				itemRigid.AddForce(resultingDirection * 1/Time.deltaTime,ForceMode.VelocityChange);
			}
			else
			{
				itemRigid.AddForce(resultingDirection * 1/Time.deltaTime * 2.0f,ForceMode.VelocityChange);
			}
			*/
			//print ("Added Force!");

			Collider[] colliders = item.GetComponents<Collider>();
			for(int i=0; i<colliders.Length; i++)
			{
				colliders[i].isTrigger = false;
			}


			if(itemParent != null)
			{
				if(!itemParent.Equals(hand.transform) || !item.transform.parent.name.Contains("unterarm"))
				{
					//print("Parent ist not hand");
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
			_hydraActive = false;
			targetRigid.constraints = RigidbodyConstraints.FreezePosition;
			handCollider.enabled = false;
			//Vector3 worldPosition = transform.TransformPoint(target.transform.position);
			Vector3 worldPosition = target.transform.position;
			target.transform.parent = null;
			target.transform.position = worldPosition;

			grabIndicator.material = grabIndicatorMaterials[0];
			grabIndicator.enabled = true;
		}
		else
		{
			//print("Ungrabbed World!");
			target.transform.parent = targets;
			_hydraActive = true;
			
			jDrive.mode = JointDriveMode.None;
			
			configJoint.xDrive = jDrive;
			configJoint.yDrive = jDrive;
			configJoint.zDrive = jDrive;
			handCollider.enabled = true;

			grabIndicator.enabled = false;

			blobbRigid.constraints = RigidbodyConstraints.None;
			blobbRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}

	public void unGrabWorld()
	{
		isGrabbingWorld = false;
		GrabWorld (false);
	}

	public void disableGrabbing()
	{
		unGrabWorld();
		grabbingIsEnabled = false;
		grabIndicator.enabled = false;
	}

	public bool getHydraStatus()
	{
		return _hydraActive;
	}

	void ProcessGrabIndicator()
	{
		if(!isGrabbingWorld && !itemIsInHand)
		{
			if(targetGrab.worldInTrigger)
			{
				grabIndicator.material = grabIndicatorMaterials[1];
				grabIndicator.enabled = true;
			}
			else
			{
				grabIndicator.enabled = false;
			}
		}
	}

	void ToogleKeyBindUI()
	{
		if(hydra.GetButtonDown(SixenseButtons.JOYSTICK))
		{
			keybindUI.SetActive(!keybindUI.activeInHierarchy);
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
