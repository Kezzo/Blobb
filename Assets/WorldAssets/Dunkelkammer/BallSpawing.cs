using UnityEngine;
using System.Collections;

public class BallSpawing : MonoBehaviour {

	public bool debugging;
	private int fieldWidth = 17;
	private int fieldDepth = 17;
	private int fieldHeight = 2;
	private float shiftX = 0.0f;
	private GameObject fieldPart;

	void Awake()
	{

		BuildingSphereField ();

	}

	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0)
		{
			BuildingSphereField ();
		}
		if (debugging) 
		{
			gameObject.BroadcastMessage("SetActiveStatus",true,SendMessageOptions.DontRequireReceiver);
		}
	}

	void BuildingSphereField ()
	{
		for(int y=0; y<fieldHeight; y++)
		{
			for(int z=0; z<fieldDepth; z++)
			{
				shiftX = 0.0f;
				
				for(int x=0; x<fieldWidth; x++){
					int randomNumber = Random.Range(1,3);
					float randomSize = Mathf.Round(Random.Range(0.3f,0.6f) * 100.0f) / 100.0f;
					shiftX += (randomSize + 0.2f);
					switch(randomNumber)
					{
					case 1: fieldPart = GameObject.CreatePrimitive (PrimitiveType.Sphere);
							fieldPart.GetComponent<SphereCollider>().material = Resources.Load("darkroom/BouncingBob") as PhysicMaterial;
							break;
					case 2: fieldPart = GameObject.CreatePrimitive (PrimitiveType.Cube);
						fieldPart.GetComponent<BoxCollider>().material = Resources.Load("darkroom/BouncingBob") as PhysicMaterial;
							break;
					}
					
					fieldPart.transform.localScale = new Vector3 (randomSize, randomSize, randomSize);
					fieldPart.GetComponent<MeshRenderer>().material = Resources.Load("darkroom/darkroom") as Material;
					fieldPart.AddComponent<BallBehavior>();
					Rigidbody rb = fieldPart.AddComponent<Rigidbody> ();
					rb.useGravity = false;
					fieldPart.transform.parent = transform;
					fieldPart.transform.localPosition = new Vector3 (-shiftX, y*-0.7f, z*-0.7f);
					fieldPart.name = "lightBall";
					fieldPart.tag = "Item";
					fieldPart.layer = LayerMask.NameToLayer("Items");
				}
			}
		}
	}


}
