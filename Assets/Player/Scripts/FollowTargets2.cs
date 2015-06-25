using UnityEngine;
using System.Collections;

public class FollowTargets2 : MonoBehaviour {

	bool collided;
	Collider collider;

	public Transform shoulder;
	public Transform inputTarget;

	public LayerMask rcLayers;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update() {
		if (collided) {
			Ray ray = new Ray(shoulder.position, inputTarget.position - shoulder.position);
			RaycastHit hit;
			
			Vector3 dir = inputTarget.position - shoulder.position;
			//int rcLayers = Physics.DefaultRaycastLayers & ~(1<<9);
			if (Physics.Raycast(ray, out hit, dir.magnitude + 0.05f, rcLayers))
			{
				print(hit.collider.gameObject.name);
				Vector3 contactPoint = hit.point - dir.normalized * 0.05f;
				transform.position = contactPoint;
			} else
				transform.position = inputTarget.position;
		} else
			transform.position = inputTarget.position;
		transform.rotation = inputTarget.rotation;
	}

	public void OnTriggerEnter(Collider other) {
		if (!collided && other.gameObject.layer == 11) {
			collided = true;
			collider = other;
		}
	}
	
	public void OnTriggerExit(Collider other) {
		if (collided && other == collider) {
			collided = false;
			collider = null;
		}
	}
}
