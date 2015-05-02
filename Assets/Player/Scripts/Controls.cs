using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public bool isRightHydra;
	public GameObject hand;
	SphereCollider handCollider;

	public float controllerOffsetY = 1.5f;
	public float controllerOffsetZ = 1.5f;

	public Transform targets;

	public bool itemInTrigger{get; set;}
	public GameObject item{get; set;}
	Collider itemCollider;
	Rigidbody itemRigid;

	Vector3 previousHandPosition =  Vector3.zero;
	Vector3 controllerPosition;

	public Transform target;
	private ConfigurableJoint configJoint;
	private Grab targetGrab;
	private Rigidbody targetRigid;

	SixenseInput.Controller hydra;

	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );

	public bool hydraActive = true;

	JointDrive jDrive = new JointDrive();

	//Rigidbody rigid;

	void Awake()
	{
		targetGrab = target.GetComponent<Grab>();
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
		Grab();

		previousHandPosition = hand.transform.position;
	}

	void FixedUpdate()
	{

	}
	
	void Grab()
	{
		if(hydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			//print (isRightHydra+"Trigger");
			if(itemInTrigger && item != null)
			{
				itemRigid = item.GetComponent<Rigidbody>();
				itemRigid.isKinematic = true;
				if(itemRigid.isKinematic)
				{
					item.transform.parent = hand.transform;
					item.transform.localPosition = new Vector3(-0.5f,0,0);
					itemCollider = item.GetComponent<Collider>();
					//item.layer = 13;
					//itemCollider.isTrigger = true;
				}
			}
			else if(targetGrab.worldTrigger)
			{
				hydraActive = false;
				targetRigid.constraints = RigidbodyConstraints.FreezePosition;
				handCollider.enabled = false;
				//Vector3 worldPosition = transform.TransformPoint(target.transform.position);
				Vector3 worldPosition = target.transform.position;
				target.transform.parent = null;
				target.transform.position = worldPosition;
				//print ("grabbed World");
			}
		}
		else if(hydra.GetButtonUp(SixenseButtons.TRIGGER))
		{
			if(item != null)
			{
				itemRigid = item.GetComponent<Rigidbody>();
				itemRigid.isKinematic = false;
				if(itemRigid.IsSleeping())
				{
					itemRigid.WakeUp();
				}

				Vector3 resultingForce = (hand.transform.position - previousHandPosition);
				itemRigid.AddForce(resultingForce * 3000.0f,ForceMode.Acceleration);

				//itemCollider = item.GetComponent<Collider>();
				//itemCollider.isTrigger = false;
				//itemCollider = null;
				//itemRigid = null;
				//item.layer = 9;

				//item.transform.parent = null;
				hand.transform.DetachChildren();
				CheckItemUnderWorld();
				item = null;
			}
			else if(targetGrab.worldTrigger)
			{
				target.transform.parent = targets;
				hydraActive = true;

				jDrive.mode = JointDriveMode.None;

				configJoint.xDrive = jDrive;
				configJoint.yDrive = jDrive;
				configJoint.zDrive = jDrive;
				handCollider.enabled = true;
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


	void LateUpdate()
	{
		// damit sich die arme mit den Targets strecken
		hand.transform.position = target.transform.position;
	}

	void CheckItemUnderWorld()
	{
		RaycastHit hitDown;
		print (item.transform.position);
		if(!Physics.Raycast(item.transform.position, Vector3.down, out hitDown))
		{
			RaycastHit hitUp;
			if(Physics.Raycast(item.transform.position, Vector3.up, out hitUp))
			{
				print (hitUp.point);
				Vector3 newPosition = hitUp.point;
				MeshRenderer mesh = item.GetComponent<MeshRenderer>();

				newPosition.y += Vector3.Distance(mesh.bounds.max,mesh.bounds.min);
				item.transform.position = newPosition;
			}
		}
	}
}
