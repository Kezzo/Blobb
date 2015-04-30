using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	Animator animator;
	public Transform leftHand;
	public Transform rightHand;


	SixenseInput.Controller leftHydra;
	SixenseInput.Controller rightHydra;

	public Vector3				Sensitivity = new Vector3( 0.01f, 0.01f, 0.01f );
	private Vector3 			leftInitialPosition;
	private Vector3 			leftBaseControllerPosition;
	private Vector3 			rightInitialPosition;
	private Vector3 			rightBaseControllerPosition;
	private bool 				leftHydraActive = false;
	private bool 				rightHydraActive = false;


	public bool ikActive = false;
	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		//animatorController.
	}
	
	// Update is called once per frame
	void Update () 
	{
		leftHydra = SixenseInput.Controllers[0];
		rightHydra = SixenseInput.Controllers[1];

		if ( leftHydra.GetButtonDown( SixenseButtons.START ) )
		{

			
			leftBaseControllerPosition = new Vector3( leftHydra.Position.x * Sensitivity.x,
			                                     leftHydra.Position.y * Sensitivity.y,
			                                     leftHydra.Position.z * Sensitivity.z );
			
			leftInitialPosition = leftHand.transform.localPosition;
			leftHydraActive = true;
		}
		
		Vector3 leftControllerPosition = new Vector3(leftHydra.Position.x * Sensitivity.x,
		                                         leftHydra.Position.y * Sensitivity.y,
		                                         leftHydra.Position.z * Sensitivity.z );

		if ( rightHydra.GetButtonDown( SixenseButtons.START ) )
		{
			
			
			rightBaseControllerPosition = new Vector3( rightHydra.Position.x * Sensitivity.x,
			                                          rightHydra.Position.y * Sensitivity.y,
			                                          rightHydra.Position.z * Sensitivity.z );
			
			rightInitialPosition = rightHand.transform.localPosition;
			rightHydraActive = true;
		}
		
		Vector3 rightControllerPosition = new Vector3(rightHydra.Position.x * Sensitivity.x,
		                                              rightHydra.Position.y * Sensitivity.y,
		                                              rightHydra.Position.z * Sensitivity.z );


		if(leftHydraActive)
		{
			leftHand.transform.localPosition = leftControllerPosition - leftBaseControllerPosition + leftInitialPosition;
			
			leftHand.transform.rotation = leftHydra.Rotation;
		}
		if(rightHydraActive)
		{
			rightHand.transform.localPosition = rightControllerPosition - rightBaseControllerPosition + rightInitialPosition;

			rightHand.transform.rotation = rightHydra.Rotation;
		}
	}

	void OnAnimatorIK(int layerIndex)
	{
		if(animator) {
			
			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {
				// Set the right hand target position and rotation, if one has been assigned
				if(rightHand != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,2);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand,2);  
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHand.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand,rightHand.rotation);
				}   
				if(leftHand != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,2);
					animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,2);  
					animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHand.position);
					animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHand.rotation);
				} 
				
			}
			
			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {          
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
				animator.SetLookAtWeight(0);
			}
		}
	} 
}
