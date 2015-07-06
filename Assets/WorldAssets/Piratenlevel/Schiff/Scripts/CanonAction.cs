using UnityEngine;
using System.Collections;

public class CanonAction : MonoBehaviour {

	public GameObject deckel;
	public bool closeDeckel;

	float speed = 1.0f;

	Vector3 targetPositionDeckel;
	Vector3 firstDeckelPosition;

	public GameObject explosionPrefab;
	public Transform explosionTransform;

	// Use this for initialization
	void Start () 
	{
		firstDeckelPosition = deckel.transform.localPosition;
		targetPositionDeckel = new Vector3(deckel.transform.localPosition.x, deckel.transform.localPosition.y - 0.3f, deckel.transform.localPosition.z - 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = speed * Time.deltaTime;
		if(closeDeckel)
		{
			//print ("Close");
			deckel.transform.localPosition = Vector3.MoveTowards(deckel.transform.localPosition, targetPositionDeckel, step);
		}
		else
		{
			//print ("Open");
			deckel.transform.localPosition = Vector3.MoveTowards(deckel.transform.localPosition, firstDeckelPosition, step);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item" && !closeDeckel) {
			StartCoroutine(ShootAfter(2.0f, other.gameObject));
		}
	}

	public IEnumerator ShootAfter(float secondsToWait, GameObject gameObjectToShoot)
	{
		closeDeckel = true;
		//print ("IEnumerator started!");
		yield return new WaitForSeconds(secondsToWait);

		Instantiate(explosionPrefab, explosionTransform.position, Quaternion.identity);
		print ("Boom");
		gameObjectToShoot.GetComponent<Rigidbody>().AddForce(this.transform.forward* 2000f);
		closeDeckel = false;
	}
}
