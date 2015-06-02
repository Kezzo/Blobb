using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reset_Button : Button {

	public bool keepCurrentObjects;

	public List<GameObject> firstGameObjects = new List<GameObject>();
	public List<GameObject> prefabGameObjects = new List<GameObject>();

	public List<SaveTransform> gameObjectTransforms = new List<SaveTransform>();

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		foreach(GameObject gameObject in firstGameObjects)
		{
			gameObjectTransforms.Add(new SaveTransform(gameObject.transform));
		}
	}
	
	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		//print ("Button Activated");
		resetGameObjects();
	}

	protected virtual void resetGameObjects()
	{
		if(!keepCurrentObjects)
		{
			foreach(GameObject gameObject in firstGameObjects)
			{
				Destroy(gameObject);
			}
			
			firstGameObjects.Clear();
		}
		//gameObjectTransforms.Clear();

		int i = 0;
		foreach(GameObject gameObject in prefabGameObjects)
		{
			firstGameObjects.Add(Instantiate(gameObject, gameObjectTransforms[i].position, gameObjectTransforms[i].rotation) as GameObject);
			i++;
		}
	}
}
