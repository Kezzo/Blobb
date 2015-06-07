using UnityEngine;
using System.Collections;

public class SpawnNewTargets : MonoBehaviour {

	public GameObject targetsPrefab;
	public GameObject currentTargets;
	DestroyBullets destroyBulletsScript;
	SaveTransform targetTransform;

	void Start()
	{
		destroyBulletsScript = currentTargets.GetComponent<DestroyBullets>();
		targetTransform = new SaveTransform(currentTargets.transform);
	}

	public void resetTargets()
	{
		destroyBulletsScript.destroyAllBulletsInList();
		
		Destroy(currentTargets);
		
		currentTargets = Instantiate(targetsPrefab, targetTransform.position, targetTransform.rotation) as GameObject;
		destroyBulletsScript = currentTargets.GetComponent<DestroyBullets>();
	}
}
