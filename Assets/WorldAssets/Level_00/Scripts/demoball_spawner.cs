using UnityEngine;
using System.Collections;

public class demoball_spawner : MonoBehaviour {
	public GameObject balls;
	public float spawnspeed=2.0f;
	float counter =0;
	// Use this for initialization
	void Start () {
		counter=spawnspeed;
	}
	
	// Update is called once per frame
	void Update () {
		counter-=Time.deltaTime;
		if (counter < 0) {

			Instantiate(balls, transform.position, transform.rotation);

			//Destroy(clone, 5);
			counter=spawnspeed;
		}
	}
}
