using UnityEngine;
using System.Collections;

public class Button_SpawnNewTargets : Button {

	public SpawnNewTargets spawnNewTargets;

	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		//print ("Button Activated");
		spawnNewTargets.resetTargets();
	}
	

}
