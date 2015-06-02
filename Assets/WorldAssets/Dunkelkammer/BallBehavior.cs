using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	public bool isActive = false;

	private Rigidbody rb;
	private MeshRenderer render;
	private int secondsToDestruction = Random.Range(1,5);
	private int secondsToChangeColor = Random.Range(1,5);
	private int randomColor = Random.Range(0,4);
	private Material[] mats = new Material[4];
	private bool changeDone = false;
	// Use this for initialization
	void Start () {
		mats[0] = Resources.Load("darkroom/blue_light") as Material;
		mats[1] = Resources.Load("darkroom/green_light") as Material;
		mats[2] = Resources.Load("darkroom/orange_light") as Material;
		mats[3] = Resources.Load("darkroom/pink_light") as Material;
		rb = GetComponent<Rigidbody>();
		render = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive == true)
		{
			//do something
			rb.useGravity = true;
			if(!changeDone)
			{
				changeColor();
			}
		}
	}

	void SetActiveStatus(bool value)
	{
		isActive = value;
	}

	void SelfDestruct()
	{
		Destroy(this.gameObject);
	}

	void OnTriggerEnter (Collider objectCollider)
	{

		if (objectCollider.name == "FloorPrototype64x01x64")
		{
			StartCoroutine(destructSequence());
		}
	}

	IEnumerator destructSequence()
	{
		yield return new WaitForSeconds(secondsToDestruction);
		SelfDestruct();
	}

	IEnumerator changeColor()
	{
		yield return new WaitForSeconds(secondsToChangeColor);
		switch(randomColor)
		{
		case 0: render.material = mats[0];
			break;
		case 1: render.material = mats[1];
			break;
		case 2: render.material = mats[2];
			break;
		case 3: render.material = mats[3];
			break;
		}
		changeDone = true;
	}
}
