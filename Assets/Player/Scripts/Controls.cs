using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public bool isRightHydra;
	public GameObject hand;

	public float controllerOffsetY = 1.5f;
	public float controllerOffsetZ = 1.5f;

	public Transform targets;

	public bool itemInTrigger{get; set;}
	public GameObject item{get; set;}
	Collider itemCollider;
	Rigidbody itemRigid;

	Vector3 previousControllerPosition =  Vector3.zero;
	Vector3 controllerPosition;

	public Transform target;
	private ConfigurableJoint configJoint;
	private Grab targetGrab;
	private Rigidbody targetRigid;

	SixenseInput.Controller hydra;

	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );

	public bool hydraActive = true;

	JointDrive jDrive = new JointDrive();

	Vector3 testV = Vector3.zero;

	Rigidbody rigid;

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

		rigid = this.GetComponent<Rigidbody>();

		jDrive.positionSpring = 50.0f;
		jDrive.maximumForce = Mathf.Infinity;

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
		previousControllerPosition = controllerPosition;

		Debug.DrawLine(this.transform.position,testV);
	}



	void Grab()
	{
		if(hydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			print (isRightHydra+"Trigger");
			if(itemInTrigger && item != null)
			{
				item.transform.parent = hand.transform;
				item.transform.localPosition = new Vector3(-0.5f,0,0);
				itemCollider = item.GetComponent<Collider>();
				itemCollider.isTrigger = true;
				itemRigid = item.GetComponent<Rigidbody>();
				itemRigid.isKinematic = true;

			}
			else if(targetGrab.worldTrigger)
			{
				hydraActive = false;
				targetRigid.constraints = RigidbodyConstraints.FreezePosition;
				//Vector3 worldPosition = transform.TransformPoint(target.transform.position);
				Vector3 worldPosition = target.transform.position;
				target.transform.parent = null;
				target.transform.position = worldPosition;
				print ("grabbed World");
			}
		}
		else if(hydra.GetButtonUp(SixenseButtons.TRIGGER))
		{
			if(itemInTrigger && item != null)
			{

				itemRigid.isKinematic = false;

				Vector3 resultingForce = controllerPosition - previousControllerPosition;
				print (resultingForce.normalized*1000.0f);
				item.transform.localEulerAngles = Vector3.zero;
				testV = resultingForce;
				itemRigid.AddForce(-item.transform.forward * 1000.0f);
				itemCollider.isTrigger = false;
				itemCollider = null;
				item.transform.parent = null;
				item = null;
				itemRigid = null;

			}
			else if(targetGrab.worldTrigger)
			{
				target.transform.parent = targets;
				hydraActive = true;

				jDrive.mode = JointDriveMode.None;

				configJoint.xDrive = jDrive;
				configJoint.yDrive = jDrive;
				configJoint.zDrive = jDrive;
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
			float currentDistance = Vector3.Distance(this.transform.position,controllerPosition + this.transform.position);
			configJoint.targetPosition = controllerPosition;
			jDrive.mode = JointDriveMode.Position;
			
			configJoint.xDrive = jDrive;
			configJoint.yDrive = jDrive;
			configJoint.zDrive = jDrive;
		}


	}

}
