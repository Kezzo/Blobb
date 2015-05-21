using UnityEngine;
using System.Collections;

public class IK : MonoBehaviour 
{
	Animator animator;

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
				if(centerEye != null) {
					animator.SetLookAtWeight(1);
					animator.SetLookAtPosition(centerEye.position);
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
}
