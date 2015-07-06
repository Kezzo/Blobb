using UnityEngine;
using System.Collections;

public class WaterBeiboot : MonoBehaviour {

	[Range(1.0f,20.0f)]
	public float speed = 1.0f;
	
	float step;

	GameObject player;
	Controls[] controlScripts;
	bool letBoatDown;
	Vector3 seaLevelPosition;

	void Update()
	{
		if(letBoatDown)
		{
			step = speed * Time.deltaTime;
			this.transform.localPosition = Vector3.MoveTowards (this.transform.localPosition, seaLevelPosition, step);
		}
	}

	public void BringBoatDown()
	{
		if(player != null && !letBoatDown)
		{
			foreach(Controls controlScript in controlScripts)
			{
				controlScript.disableGrabbing();
			}
			seaLevelPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 6.5f, this.transform.localPosition.z - 2.0f);
			letBoatDown = true;
		}
	}

	public void disableLetBoatDown()
	{
		letBoatDown = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Blobb")
		{
			controlScripts = other.GetComponents<Controls>();
			player = other.transform.root.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "Blobb")
		{
			player = null;
		}
	}
}
