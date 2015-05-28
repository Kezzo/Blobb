using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_SpawnNewTargets : Button {

	public GameObject Target;
	public GameObject currentTarget;
	public Transform targetTransform;

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

		currentTarget = Instantiate(Target, targetTransform.position, targetTransform.rotation) as GameObject;

	}
}
