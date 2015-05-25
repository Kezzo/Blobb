using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_Dosenaufsteller : Button {

	public GameObject dosenTurm;
	List<GameObject> dosenTuerme = new List<GameObject>();

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
		print ("Button Activated");
		spawnDosen();
	}
	void spawnDosen()
	{
		foreach(GameObject dosenTurmObject in dosenTuerme)
		{
			Destroy(dosenTurmObject);
		}
		dosenTuerme.Add(Instantiate(dosenTurm, new Vector3(-17.4f, 2.39f, 5.44f), Quaternion.Euler(0.0f,-45.0f,0.0f)) as GameObject);
		dosenTuerme.Add(Instantiate(dosenTurm, new Vector3(-20.9f, 2.39f, 8.9f), Quaternion.Euler(0.0f,-45.0f,0.0f)) as GameObject);
		dosenTuerme.Add(Instantiate(dosenTurm, new Vector3(-14.15f, 2.39f, 2.15f), Quaternion.Euler(0.0f,-45.0f,0.0f)) as GameObject);
	}
}
