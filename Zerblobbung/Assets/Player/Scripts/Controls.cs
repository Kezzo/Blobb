using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public Transform targets;

	public Transform leftHand;
	private SpringJoint leftSpringJoint;
	private Grab leftHandGrab;
	private Rigidbody leftRigid;

	public Transform rightHand;
	private SpringJoint rightSpringJoint;
	private Grab rightHandGrab;
	private Rigidbody rightRigid;

	SixenseInput.Controller leftHydra;
	SixenseInput.Controller rightHydra;

	public Vector3 Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );

	private bool leftHydraActive = true;
	private bool rightHydraActive = true;


	Rigidbody rigid;

	void Awake()
	{
		rightHandGrab = rightHand.GetComponent<Grab>();
		rightSpringJoint = this.GetComponents<SpringJoint>()[0];
		rightRigid = rightHand.GetComponent<Rigidbody>();

		leftHandGrab = leftHand.GetComponent<Grab>();
		leftSpringJoint = this.GetComponents<SpringJoint>()[1];
		leftRigid = leftHand.GetComponent<Rigidbody>();

		rigid = this.GetComponent<Rigidbody>();

	}

	// Use this for initialization

	
	// Update is called once per frame
	void Update () 
	{
		leftHydra = SixenseInput.Controllers[0];
		rightHydra = SixenseInput.Controllers[1];

		MoveHands();
		Grab();
	}



	void Grab()
	{
		if(leftHydra.GetButton(SixenseButtons.TRIGGER))
		{
			print ("leftTrigger");
		}

		if(rightHydra.GetButtonDown(SixenseButtons.TRIGGER))
		{
			print ("rightTrigger");

			if(rightHandGrab.worldTrigger)
			{
				rightHydraActive = false;
				rightRigid.constraints = RigidbodyConstraints.FreezePosition;
				Vector3 worldPosition = transform.TransformPoint(rightHand.transform.position);
				rightHand.transform.parent = null;
				rightHand.transform.position = worldPosition;
				print ("grabbed World");
			}
		}
		else if(rightHydra.GetButtonUp(SixenseButtons.TRIGGER))
		{
			if(rightHandGrab.worldTrigger)
			{
				rightHand.transform.parent = targets;
				rightHydraActive = true;
				rightSpringJoint.minDistance = 1000.0f;
			}
		}
	}

	void MoveHands()
	{
		Vector3 leftControllerPosition = new Vector3(leftHydra.Position.x * Sensitivity.x,
		                                             leftHydra.Position.y * Sensitivity.y,
		                                             leftHydra.Position.z * Sensitivity.z );
		leftControllerPosition.y -= 1.5f;

		Vector3 rightControllerPosition = new Vector3(rightHydra.Position.x * Sensitivity.x,
		                                              rightHydra.Position.y * Sensitivity.y,
		                                              rightHydra.Position.z * Sensitivity.z );
		
		
		if(leftHydraActive)
		{
			leftHand.transform.localPosition = leftControllerPosition;
			
			leftHand.transform.rotation = leftHydra.Rotation;
		}
		else
		{
			float currentDistance = Vector3.Distance(this.transform.position,rightControllerPosition + this.transform.position);
			rightSpringJoint.minDistance = currentDistance/2;
		}

		if(rightHydraActive)
		{
			rightHand.transform.localPosition = rightControllerPosition;
			
			rightHand.transform.rotation = rightHydra.Rotation;
		}
		else
		{
			float currentDistance = Vector3.Distance(this.transform.position,rightControllerPosition + this.transform.position);
			rightSpringJoint.minDistance = currentDistance/2;
		}
	}


}
