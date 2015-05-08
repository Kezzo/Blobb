using UnityEngine;
using System.Collections;

public class BallRespawn : MonoBehaviour {


	public GameObject firstBall;
	GameObject ballClone;
	float zPos;

	void Start()
	{
		SpawnBall ();
	}
	// Update is called once per frame
	void Update () 
	{

		float yPos = ballClone.transform.position.y;
		zPos = ballClone.transform.position.z;
		if (yPos < -10) 
		{
			Destroy(ballClone);
			SpawnBall();
		}
	}

	void SpawnBall()
	{
		Vector3 spawnPoint;
		if (zPos > 87f) {
			spawnPoint = new Vector3(43f, 11f, 80f);
		}
		else
		{
		 	spawnPoint = transform.position + firstBall.transform.position;
		}
		ballClone = (GameObject)Instantiate (firstBall, spawnPoint, transform.rotation);
		//ballClone.transform.parent = transform;
	}
}
