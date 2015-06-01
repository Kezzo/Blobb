using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_Dosenaufsteller : Button {

	public GameObject dosenTurm;
	public List<GameObject> dosenTuerme = new List<GameObject>();

	public Transform[] dosenturmPositions;

	public DestroyBullets destroyBullets;

	// Use this for initialization
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
		//print ("Button Activated");
		resetTargets();
		destroyBullets.destroyAllBulletsInList();
	}
	void resetTargets()
	{
		foreach(GameObject dosenTurmObject in dosenTuerme)
		{
			Destroy(dosenTurmObject);
		}

		for(int i=0; i<dosenturmPositions.Length; i++)
		{
			dosenTuerme.Add(Instantiate(dosenTurm, dosenturmPositions[i].position, dosenturmPositions[i].rotation) as GameObject);
		}
	}
}
