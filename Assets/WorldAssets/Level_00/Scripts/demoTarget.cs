﻿using UnityEngine;
using System.Collections;

public class demoTarget : MonoBehaviour {

	public Material wasHitMaterial;
	public Material notHitMaterial;
	public GameObject activateThis;
	public GameObject deactivateThis;
	MeshRenderer meshRenderer;
	Material[] materials;
	bool change=false;
	bool changeback=false;
	public float counter=0.2f;

	// Use this for initialization
	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		materials = meshRenderer.materials;
	}
	
	// Update is called once per frame
	void Update () {
	if (change == true) {
			materials[1] = wasHitMaterial;
			meshRenderer.materials = materials;
			counter-=Time.deltaTime;

			/*if(counter<0)
			{
				change=false;
				changeback=true;
				counter=0.2f;
			}*/
		}
		if (changeback == true) {
			materials[1] = notHitMaterial;
			meshRenderer.materials = materials;
			changeback=false;
		}
	}

	void OnCollisionEnter(Collision enter)
	{
		if((enter.collider.name.Contains("Ball") || enter.collider.name.Contains("Bullet"))  && !change)
		{
			change = true;
			if (activateThis) {
				activateThis.SendMessage("OpenDoor");
			}
			if (deactivateThis) {
				//deactivateThis.SendMessage("deactivate");
			}
		}
	}
}
