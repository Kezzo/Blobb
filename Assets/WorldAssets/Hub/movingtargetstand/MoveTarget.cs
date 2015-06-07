using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {

	public bool moveUpAndDown;
	public Material wasHitMaterial;
	bool goBack;
	Rigidbody rigid;
	bool wasHit;
	MeshRenderer meshRenderer;
	Material[] materials;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody>();
		meshRenderer = GetComponent<MeshRenderer>();
		materials = meshRenderer.materials;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!wasHit)
		{
			if(moveUpAndDown)
			{
				if(goBack)
				{
					this.transform.Translate(Vector3.back * Time.deltaTime);
				}
				else
				{
					this.transform.Translate(Vector3.forward * Time.deltaTime);
				}
			}
			else
			{
				if(goBack)
				{
					this.transform.Translate(Vector3.right * Time.deltaTime);
				}
				else
				{
					this.transform.Translate(Vector3.left * Time.deltaTime);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("Targets"))
		{
			goBack = !goBack;
		}
	}

	void OnCollisionEnter(Collision collsion)
	{
		if(collsion.collider.tag == "Item")
		{
			materials[1] = wasHitMaterial;
			meshRenderer.materials = materials;
			wasHit = true;
			rigid.useGravity = true;
		}
		//Debug.Log(collsion.collider.name);
	}
}
