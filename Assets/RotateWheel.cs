using UnityEngine;
using System.Collections;

public class RotateWheel : MonoBehaviour {

	SixenseInput.Controller hydra;
	bool isForRightHand;
	public GameObject hand;
	Vector3 previousHandPosition;
	bool grabbedWorldObject;
	public enum IsRotation{Not, Right, Left};
	public IsRotation isRotation = IsRotation.Not;

	bool handIsRightOfWheel;

	[Range(5,50)]
	public float wheelRotationMultiplier;
	float wheelRotationSpeed;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isForRightHand)
		{
			hydra = SixenseInput.Controllers[1];
		}
		else
		{
			hydra = SixenseInput.Controllers[0];
		}

		if (hand != null) {
			if (hydra.GetButton (SixenseButtons.TRIGGER)) {
				MoveWorldObject();
			}
			else
			{
				isRotation = IsRotation.Not;
			}

			previousHandPosition = hydra.Position;
		}
	}

	void MoveWorldObject()
	{
		// negative is right, positive is left 
		float rightLeftDifference = previousHandPosition.x - hydra.Position.x;

		// negative is up, positive is down
		float upDownDifference = previousHandPosition.y - hydra.Position.y;

		isRotation = IsRotation.Not;

		bool oben = hand.transform.position.y > this.transform.position.y;
//		bool rechts = hand.transform.position.x > this.transform.position.x;

		float handDifference = Mathf.Max(Mathf.Abs(rightLeftDifference), Mathf.Abs(upDownDifference));
		wheelRotationSpeed = handDifference * wheelRotationMultiplier;

		if(handDifference > 1.0f)
		{
			if(Mathf.Abs(rightLeftDifference) > Mathf.Abs(upDownDifference))
			{
				if((rightLeftDifference < 0.0f && oben) || (rightLeftDifference > 0.0f && !oben))
				{
					rotateWheel(wheelRotationSpeed);
				}
				else if((rightLeftDifference > 0.0f && oben) || (rightLeftDifference < 0.0f && !oben))
				{
					rotateWheel(-wheelRotationSpeed);
				}
			}
			else if(Mathf.Abs(rightLeftDifference) < Mathf.Abs(upDownDifference))
			{

				if((upDownDifference < 0.0f && handIsRightOfWheel) || (upDownDifference > 0.0f && !handIsRightOfWheel))
				{
					rotateWheel(-wheelRotationSpeed);
				}
				else if((upDownDifference > 0.0f && handIsRightOfWheel) || (upDownDifference < 0.0f && !handIsRightOfWheel))
				{
					rotateWheel(wheelRotationSpeed);
				}
			}
		}
	}

	void rotateWheel(float valueToChange)
	{
		if (valueToChange > 0.0f) {
			isRotation = IsRotation.Left;
		} else if( valueToChange < 0.0f)
		{
			isRotation = IsRotation.Right;
		}

		this.transform.Rotate (Vector3.up, valueToChange * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		//print (other.name);
		if (other.name.Contains ("unterarm") && hand == null) {
			hand = other.gameObject;
			if(other.name == "unterarm_l")
			{
				isForRightHand = false;
			}
			else if(other.name == "unterarm_r")
			{
				isForRightHand = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		//print (other.name);
		if (other.name.Contains ("unterarm")) {
			hand = null;
			isRotation = IsRotation.Not;
		}
	}

	public float getWheelRotationSpeed()
	{
		return wheelRotationSpeed;
	}

	public void setIfHandIsRight(bool handIsRight)
	{
		this.handIsRightOfWheel = handIsRight;
	}
}
