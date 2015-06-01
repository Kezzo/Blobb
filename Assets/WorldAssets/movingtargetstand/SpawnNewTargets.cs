using UnityEngine;
using System.Collections;

public class SpawnNewTargets : MonoBehaviour {

	public GameObject targetsPrefab;
	public GameObject currentTargets;
	public Transform targetTransform;
	DestroyBullets destroyBulletsScript;

	void Start()
	{
		destroyBulletsScript = currentTargets.GetComponent<DestroyBullets>();
	}

	public void resetTargets()
	{
		destroyBulletsScript.destroyAllBullets();
		
		Destroy(currentTargets);
		
		currentTargets = Instantiate(targetsPrefab, targetTransform.position, targetTransform.rotation) as GameObject;
		destroyBulletsScript = currentTargets.GetComponent<DestroyBullets>();
	}
}
