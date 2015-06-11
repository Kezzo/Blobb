using UnityEngine;
using System.Collections;

public class BulletThroughTargetTest : MonoBehaviour {

	PrimitiveCannon canon;
	float time;
	public int bulletsShot;
	public int targetHits = 2;
	// Use this for initialization
	void Start () {
		canon = GameObject.Find ("PrimitiveCannon").GetComponent<PrimitiveCannon>();
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		//Tausend Schüsse auf eine bestimmte Entfernung testen 
		if (time > 0.1f && bulletsShot < 10) {
			canon.UseOnce ();
			time = 0.0f;
			bulletsShot ++;
		}

	}
	void OnCollisionEnter(Collision bullet)
	{
		targetHits ++;
	}
}
