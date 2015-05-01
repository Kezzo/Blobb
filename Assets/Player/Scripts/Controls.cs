using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public bool isRightHydra;

	public float controllerOffsetY = 1.5f;
	public float controllerOffsetZ = 1.5f;

	public Transform targets;

	public Transform target;
	private SpringJoint springJoint;
	private Grab targetGrab;
	private Rigidbody targetRigid;

	SixenseInput.Controller hydra;

	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );

	public bool hydraActive = true;


	Rigidbody rigid;

	void Awake()
	{
		targetGrab = target.GetComponent<Grab>();
		if(isRightHydra)
		{
			springJoint = this.GetComponents<SpringJoint>()[0];
		}
		else
		{
			springJoint = this.GetComponents<SpringJoint>()[1];
		}
		targetRigid = target.GetComponent<Rigidbody>();

		rigid = this.GetComponent<Rigidbody>();

	}

	void Update () 
	{
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
	}



	void Grab()
	{
		if(hydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			print (isRightHydra+"Trigger");

			if(targetGrab.worldTrigger)
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

			target.transform.parent = targets;
			hydraActive = true;
			springJoint.minDistance = 1000.0f;
			springJoint.maxDistance = 0.0f;

		}
	}

	void MoveHands()
	{
		Vector3 controllerPosition = new Vector3(hydra.Position.x * Sensitivity.x,
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
			springJoint.minDistance = currentDistance/2;
			springJoint.maxDistance = currentDistance/2 - 0.01f;
		}
	}


}
