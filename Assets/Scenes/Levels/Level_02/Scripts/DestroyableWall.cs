using UnityEngine;
using System.Collections;

public class DestroyableWall : MonoBehaviour
{

	bool bigBlock = false;
	int zSwitch = 1;
	int wallWidth = 26;
	int wallHeight = 15;
	float spawnSpeed = 0.0f;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (BuildingWall ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator BuildingWall ()
	{

		for (int y = 0; y < wallHeight; y++) 
		{
			yield return new WaitForSeconds (spawnSpeed);
			if(y%2 == 0)
			{
				bigBlock = true;
				zSwitch = 1;
				if(y > 0)
				{
					wallWidth = wallWidth-1;
				}


			}
			else
			{
				bigBlock = false;
				zSwitch = 1;
				wallWidth = wallWidth+1;
			}

			for (int z = 0; z < zSwitch; z++) 
			{
				yield return new WaitForSeconds (spawnSpeed);
				for (int x = 0; x < wallWidth; x++) 
				{
					yield return new WaitForSeconds (spawnSpeed);
					GameObject wallPart = GameObject.CreatePrimitive (PrimitiveType.Cube);
					if(bigBlock)
					{
						wallPart.transform.localScale = new Vector3 (1.5f, 1.0f, 1.0f);
					}
					else
					{
						if(x == 0 || x == 26)
						{
							wallPart.transform.localScale = new Vector3 (0.75f, 1f, 1.0f);
						}
						else 
						{
							wallPart.transform.localScale = new Vector3 (1.5f, 1f, 1.0f);
						}
					}
					//wallPart.transform.localScale = new Vector3 (1f, 0.5f, 1f);
//					Rigidbody rb = wallPart.AddComponent<Rigidbody> ();
					//rb.mass = 1;
					//rb.useGravity = false;
					wallPart.transform.parent = transform;
					if(bigBlock)
					{
						wallPart.transform.localPosition = new Vector3 (x*1.5f, y, z);
					}
					else
					{
						if(x == 0)
						{
							wallPart.transform.localPosition = new Vector3 (x-0.25f, y, z);
						}
						else if(x == 26)
						{
							wallPart.transform.localPosition = new Vector3 (x*1.5f-1f, y, z);
						}
						else 
						{
							wallPart.transform.localPosition = new Vector3 (((x-1)*1.5f)+0.75f, y, z);
						}

					}
					wallPart.tag = "Item";
					wallPart.layer = LayerMask.NameToLayer("Items");

					//wallPart.transform.localPosition = new Vector3 (x*1f, y * 0.5f, z*1f);
					//Collider col = wallPart.GetComponent<BoxCollider>();
					//col.material = friction;

				}
			}
		}
		/*for(int i = 1403; i>0 ; i--)
		{
			GameObject ChildGameObject = transform.GetChild(i).gameObject;
			Rigidbody rb = ChildGameObject.AddComponent<Rigidbody> ();
		}*/
	}


}
