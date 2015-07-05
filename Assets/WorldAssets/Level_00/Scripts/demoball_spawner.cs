using UnityEngine;
using System.Collections;

public class demoball_spawner : MonoBehaviour {
	public GameObject balls;
	public float spawnspeed=2.0f;
	float counter =0;
	public bool active=true;

	[Range(1,20)]
	public int maxBalls;
	int currentBallCount;

	// Use this for initialization
	void Start () {
		counter=spawnspeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (active == true) {
			counter-=Time.deltaTime;
			if (counter < 0 && currentBallCount < maxBalls) {
				
				Instantiate(balls, transform.position, transform.rotation);
				currentBallCount++;
				
				//Destroy(clone, 5);
				counter=spawnspeed;
			}
		}
	
	}

	public void deactivate(){
		active = false;
	}

	public void ReduceBallCountBy(int countToReduce)
	{
		currentBallCount -= countToReduce;
	}
}
