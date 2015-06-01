using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Material activateMaterial;
	public Material deactivateMaterial;

	bool active = true;
	float cooldown = 5.0f;

	MeshRenderer meshRenderer;

	protected virtual void Start()
	{
		meshRenderer = this.GetComponent<MeshRenderer>();
	}
	
	protected virtual void Update()
	{
		if(!active)
		{
			cooldown -= Time.deltaTime;
			if(cooldown < 0.0f)
			{
				active = true;
				meshRenderer.material = activateMaterial;
			}
		}
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		if((other.name.Contains("Target") || other.tag == "Item") && active)
		{
			active = false;
			meshRenderer.material = deactivateMaterial;
			cooldown = 5.0f;
			OnButtonActivation();
		}
		//print (other.name);
	}

	protected virtual void OnButtonActivation()
	{
		// Change to fit Button purpose
		//print ("OnButtonActivation Parent");
	}
}
