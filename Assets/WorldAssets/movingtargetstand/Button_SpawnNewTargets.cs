using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_SpawnNewTargets : Button {

	public GameObject Target;
	public GameObject currentTarget;

	protected override void Start () 
	{
		base.Start();
		
		//spawnDosen();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update ();
	}
	
	protected override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		print ("OnTriggerEnter");
	}
	
	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		print ("Button Activated");
		spawnTargets();
	}
	
	void spawnTargets()
	{
		Destroy(currentTarget);

		currentTarget = Instantiate(Target, new Vector3(24.0f, 1.24f, 4.89f), Quaternion.Euler(270.0f,-136.3f,0.0f)) as GameObject;

	}
}
