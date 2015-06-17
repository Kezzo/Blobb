using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {
	
	Schiffssteuerung schiffsteuerung;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		schiffsteuerung = GameObject.Find ("Schiff").GetComponent<Schiffssteuerung> ();

		rb = GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 5);
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
