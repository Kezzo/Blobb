using UnityEngine;
using System.Collections;

public class SinkShip : MonoBehaviour 
{
	int hits;
	public bool isSinking;
	[Range(1,10)]
	public float sinkSpeed = 1.0f;

	Vector3 endPosition;
	//Vector3 endRotation;

	void Start()
	{
		//startPosition = this.transform.position;
		//endPosition = new Vector3(startPosition.x, startPosition.y-50.0f, startPosition.z);
	}

	void Update()
	{
		if(isSinking)
		{
			float step = sinkSpeed * Time.deltaTime;
			transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, endPosition, step);
			//float angle =  Mathf.LerpAngle(0.0f, 90.0f, Time.deltaTime * 0.5f);
			//transform.rotation = Quaternion.FromToRotation(transform.rotation, Vector3.down, step, 0.0f);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		print (collision.gameObject.name);
		if(collision.gameObject.name.Contains("Kanonenkugel"))
		{
			hits ++;
			if(hits == 2 && !isSinking)
			{
				isSinking = true;
				endPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 10.0f, this.transform.localPosition.z);
				//endRotation = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 1.0f);
			}
		}
	}

	public bool getIsSinking()
	{
		return isSinking;
	}
}

