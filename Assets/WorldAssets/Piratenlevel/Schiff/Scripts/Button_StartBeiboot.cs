using UnityEngine;
using System.Collections;

public class Button_StartBeiboot : Button {

	public GameObject beiboot;

	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		//print ("Button Activated");
		beiboot.GetComponent<WaterBeiboot>().BringBoatDown();
	}
}
