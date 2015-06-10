using UnityEngine;
using System.Collections;

public class demoFire : MonoBehaviour {
	public GameObject leftGun;
	public GameObject rightGun;
	bool fireleft=false;
	bool fireright=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fireleft == true) {
			leftGun.GetComponent<PrimitiveCannon>().UseOnce();
			fireleft=false;
		}
		if (fireright == true) {
			rightGun.GetComponent<PrimitiveCannon>().UseOnce();
			fireright=false;
		}
	//	leftGun.GetComponent<PrimitiveCannon>().UseOnce();
	//	rightGun.GetComponent<PrimitiveCannon>().UseOnce();
	}
	void OnTriggerExit(Collider exit){

		if (exit.gameObject == rightGun) {
			fireleft = true;
		}
		if (exit.gameObject == leftGun) {
			fireright = true;
		}
	}
}
