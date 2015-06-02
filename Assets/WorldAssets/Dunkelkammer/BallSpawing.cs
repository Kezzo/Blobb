using UnityEngine;
using System.Collections;

public class BallSpawing : MonoBehaviour {
	
	int fieldWidth = 17;
	int fieldDepth = 17;
	int fieldHeight = 3;
	float shiftX = 0.0f;
	float spawnSpeed = 0.0f;
	GameObject fieldPart;
	SphereCollider sphereColl;
	BoxCollider boxColl;
	public bool debugging;

	void Awake()
	{
		BuildingSphereField ();
	}
	// Use this for initialization
	void Start () {
		//StartCoroutine (BuildingSphereField ());

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0)
		{
			BuildingSphereField ();
		}
	}

	/*IEnumerator BuildingSphereField ()
	{
		for(int y=0; y<fieldHeight; y++)
		{
			yield return new WaitForSeconds (spawnSpeed);
			for(int z=0; z<fieldDepth; z++)
			{
				yield return new WaitForSeconds (spawnSpeed);
				shiftX = 0.0f;

				for(int x=0; x<fieldWidth; x++){
					yield return new WaitForSeconds (spawnSpeed);
					int randomNumber = Random.Range(1,3);
					float randomSize = Mathf.Round(Random.Range(0.3f,0.6f) * 100.0f) / 100.0f;
					shiftX += (randomSize + 0.2f);
					switch(randomNumber)
					{
					case 1: fieldPart = GameObject.CreatePrimitive (PrimitiveType.Sphere);
						break;
					case 2: fieldPart = GameObject.CreatePrimitive (PrimitiveType.Cube);
						break;
					}

					fieldPart.transform.localScale = new Vector3 (randomSize, randomSize, randomSize);
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
	}*/

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
					
						sphereColl = fieldPart.GetComponent<SphereCollider>();
						PhysicMaterial bob = Resources.Load("BouncingBob") as PhysicMaterial;
						sphereColl.material = bob;
						break;
					case 2: fieldPart = GameObject.CreatePrimitive (PrimitiveType.Cube);
							boxColl = fieldPart.GetComponent<BoxCollider>();
							boxColl.material = (PhysicMaterial)Resources.Load("BouncingBob");
						break;
					}
					
					fieldPart.transform.localScale = new Vector3 (randomSize, randomSize, randomSize);
					fieldPart.AddComponent<BallBehavior>();
					Rigidbody rb = fieldPart.AddComponent<Rigidbody> ();
					rb.useGravity = false;
					//coll.material = (PhysicMaterial)Resources.Load("BouncingBob");
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
