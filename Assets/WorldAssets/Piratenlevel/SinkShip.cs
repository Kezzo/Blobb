using UnityEngine;
using System.Collections;

public class SinkShip : MonoBehaviour 
{
	int hits;
	bool isSinking;

	//Vector3 startPosition;
	//Vector3 endPosition;

	void Start()
	{
		//startPosition = this.transform.position;
		//endPosition = new Vector3(startPosition.x, startPosition.y-50.0f, startPosition.z);
	}

	void Update()
	{
		if(isSinking)
		{
//			float step = 5.0f * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(startPosition, endPosition, step);
			//float angle =  Mathf.LerpAngle(0.0f, 90.0f, Time.deltaTime * 0.5f);
			//this.transform.eulerAngles = new Vector3(0,0,angle);
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
			}
		}
	}

	public bool getIsSinking()
	{
		return isSinking;
	}
}

