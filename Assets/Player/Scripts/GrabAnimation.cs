using UnityEngine;
using System.Collections;

public class GrabAnimation : MonoBehaviour {

	public bool isRight;
	//Quaternion rotation;

	void LateUpdate () 
	{

		if(isRight)
		{
			transform.localScale = new Vector3(transform.localScale.x, 1 - (SixenseInput.Controllers[1].Trigger / 2), 1 - (SixenseInput.Controllers[1].Trigger / 2));
			//rotation = Quaternion.Euler(new Vector3(-90.0f + SixenseInput.Controllers[1].Trigger * 90.0f,0,0));
		}
		else
		{
			transform.localScale = new Vector3(transform.localScale.x, 1 - (SixenseInput.Controllers[0].Trigger / 2), 1 - (SixenseInput.Controllers[0].Trigger / 2));
			//rotation = Quaternion.Euler(new Vector3(90.0f + SixenseInput.Controllers[0].Trigger * 90.0f,0,0));
		}

		//this.transform.localRotation = rotation;
	
	}
}
