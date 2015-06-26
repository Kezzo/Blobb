using UnityEngine;
using System.Collections;

public class demoball_spawner : MonoBehaviour {
	public GameObject balls;
	public float spawnspeed=2.0f;
	float counter =0;
	public bool active=true;
	// Use this for initialization
	void Start () {
		counter=spawnspeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (active == true) {
			counter-=Time.deltaTime;
			if (counter < 0) {
				
				Instantiate(balls, transform.position, transform.rotation);
				
				//Destroy(clone, 5);
				counter=spawnspeed;
			}
		}
	
	}

	public void deactivate(){
		active = false;
	}
}
