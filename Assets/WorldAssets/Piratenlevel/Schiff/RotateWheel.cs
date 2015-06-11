using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateWheel : MonoBehaviour {

	SixenseInput.Controller hydra;

	List<GameObject> _handsList = new List<GameObject>();
	public List<GameObject> handList
	{
		get
		{
			return _handsList;
		}
	}

	Vector3 previousHandPositionRight;
	Vector3 previousHandPositionLeft;

	//bool grabbedWorldObject;
	public enum IsRotation{Not, Right, Left};
	public IsRotation isRotation = IsRotation.Not;

	bool isRightHandRight;
	bool isLeftHandRight;

	[Range(5,50)]
	public float wheelRotationMultiplier;
	float wheelRotationSpeed;

	bool _isGrabbing;
	public bool isGrabbing
	{
		get
		{
			return _isGrabbing;
		}
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		_isGrabbing = false;
		isRotation = IsRotation.Not;
		if (_handsList.Count > 0) {

			foreach(GameObject hand in _handsList)
			{
				if(hand.name == "unterarm_r")
				{
					hydra = SixenseInput.Controllers[1];
				}
				else if(hand.name == "unterarm_l")
				{
					hydra = SixenseInput.Controllers[0];
				}

				if (hydra.GetButton (SixenseButtons.TRIGGER)) {
					//print ("Button from: "+hand.name);
					if(hand.name == "unterarm_r")
					{
						MoveWheel(hydra, hand.name == "unterarm_r", hand, isRightHandRight);
					}
					else if(hand.name == "unterarm_l")
					{
						MoveWheel(hydra, hand.name == "unterarm_r", hand, isLeftHandRight);
					}
					if(!_isGrabbing)
					{
						_isGrabbing = true;
					}
				}

				if(hand.name == "unterarm_r")
				{
					previousHandPositionRight = hydra.Position;
				}
				else if(hand.name == "unterarm_l")
				{
					previousHandPositionLeft = hydra.Position;
				}
			}
		}
	}

	void MoveWheel(SixenseInput.Controller currentHydra, bool isRightHydra, GameObject currentHand, bool handIsRight)
	{
		//print ("MoveWheel "+isRightHydra);
		float rightLeftDifference;
		float upDownDifference;
		bool aboveMid;

		if(isRightHydra)
		{
			// negative is right, positive is left 
			rightLeftDifference = previousHandPositionRight.x - currentHydra.Position.x;
			
			// negative is up, positive is down
			upDownDifference = previousHandPositionRight.y - currentHydra.Position.y;

			aboveMid = currentHand.transform.position.y > this.transform.position.y;
		}
		else
		{
			// negative is right, positive is left 
			rightLeftDifference = previousHandPositionLeft.x - currentHydra.Position.x;
			
			// negative is up, positive is down
			upDownDifference = previousHandPositionLeft.y - currentHydra.Position.y;

			aboveMid = currentHand.transform.position.y > this.transform.position.y;
		}

		//print (currentHydra.Position.x);

		//print ("rightLeftDifference: "+rightLeftDifference);
		//print ("upDownDifference: "+upDownDifference);

		//isRotation = IsRotation.Not;


//		bool rechts = hand.transform.position.x > this.transform.position.x;

		float handDifference = Mathf.Max(Mathf.Abs(rightLeftDifference), Mathf.Abs(upDownDifference));
		wheelRotationSpeed = handDifference * wheelRotationMultiplier;

		if(handDifference > 1.0f)
		{
			if(Mathf.Abs(rightLeftDifference) > Mathf.Abs(upDownDifference))
			{
				//print ("rechtslinks");
				if((rightLeftDifference < 0.0f && aboveMid) || (rightLeftDifference > 0.0f && !aboveMid))
				{
					//print ("oben/rechts oder unten/links");
					rotateWheel(wheelRotationSpeed);
				}
				else if((rightLeftDifference > 0.0f && aboveMid) || (rightLeftDifference < 0.0f && !aboveMid))
				{
					//print ("oben/links oder unten/rechts");
					rotateWheel(-wheelRotationSpeed);
				}
			}
			else if(Mathf.Abs(rightLeftDifference) < Mathf.Abs(upDownDifference))
			{
				//print ("hochrunter");
				//print ("rechts: "+isRightHandRight.Equals(currentHand));
				if((upDownDifference < 0.0f && handIsRight) || (upDownDifference > 0.0f && !handIsRight))
				{
					//print ("rechts/hoch oder links/runter");
					rotateWheel(-wheelRotationSpeed);
				}
				else if((upDownDifference > 0.0f && handIsRight) || (upDownDifference < 0.0f && !handIsRight))
				{
					//print ("rechts/runter oder links/hoch");
					rotateWheel(wheelRotationSpeed);
				}
			}
		}
	}

	public float getWheelRotation()
	{
		return this.transform.localRotation.eulerAngles.y;
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
		if (other.name.Contains ("unterarm")) 
		{
			if(_handsList.Count > 0)
			{
				foreach(GameObject hand in _handsList.ToArray())
				{
					if(!other.gameObject.Equals(hand))
					{
						_handsList.Add(other.gameObject);
						//print ("Hand added: "+other.gameObject.name);
					}
					
				}
			}
			else
			{
				_handsList.Add(other.gameObject);
				//print ("Hand added: "+other.gameObject.name);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		//print (other.name);
		if (other.name.Contains ("unterarm")) {
			foreach(GameObject hand in _handsList.ToArray())
			{
				if(other.gameObject.Equals(hand))
				{
					_handsList.Remove(hand);
					//print ("Hand removed: "+other.gameObject.name);
				}
				
			}

			if(_handsList.Count == 0)
			{
				isRotation = IsRotation.Not;
			}

		}
	}

	public float getWheelRotationSpeed()
	{
		return wheelRotationSpeed;
	}

	public void setRightHandIsRight(bool rightHandIsRight)
	{
		this.isRightHandRight = rightHandIsRight;
	}

	public void setLeftHandIsRight(bool leftHandIsRight)
	{
		this.isLeftHandRight = leftHandIsRight;
	}
}
