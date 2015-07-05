using UnityEngine;
using System.Collections;

public class destroyDemoBalls : MonoBehaviour {
	public float destroytime=8.0f;

	public demoball_spawner spawner;
	public bool callSpawner;

	void OnTriggerEnter(Collider enter)
	{
		if (enter.CompareTag ("Item")) {

			Destroy (enter.gameObject, destroytime);
			if(callSpawner)
			{
				spawner.ReduceBallCountBy(1);
			}

		}

	}
}
