using UnityEngine;
using System.Collections;

public class IK : MonoBehaviour 
{
	Animator animator;

	public Transform leftTarget;
	public Transform rightTarget;
	public Transform leftHand;
	public Transform rightHand;
	public Transform centerEye;
	public bool ikActive = false;

	void Awake () 
	{
		animator = this.GetComponent<Animator>();
	}
	void OnAnimatorIK(int layerIndex)
	{
		if(animator) {
			
			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive)
			{
				// Set the right hand target position and rotation, if one has been assigned
				if(rightTarget != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,2);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand,2);  
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightTarget.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand,rightTarget.rotation);
				}   
				if(leftTarget != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,2);
					animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,2);  
					animator.SetIKPosition(AvatarIKGoal.LeftHand,leftTarget.position);
					animator.SetIKRotation(AvatarIKGoal.LeftHand,leftTarget.rotation);
				} 
				if(centerEye != null) {
					//animator.SetLookAtWeight(1);
					//animator.SetLookAtPosition(centerEye.position);
				} 
				
			}
			
			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else 
			{          
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
				animator.SetLookAtWeight(0);
			}
		}
	}
	void LateUpdate()
	{
		//allow the Tentacles to follow their Targets, i.e stretching
		rightHand.transform.position = rightTarget.transform.position;
		leftHand.transform.position = leftTarget.transform.position;
	}
}
