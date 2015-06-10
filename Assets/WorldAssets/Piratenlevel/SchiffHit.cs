using UnityEngine;
using System.Collections;

public class SchiffHit : MonoBehaviour {

	public GameObject explosionPrefab;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.name.Contains("feind"))
		{
			Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
