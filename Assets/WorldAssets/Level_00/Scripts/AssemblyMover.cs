using UnityEngine;
using System.Collections;

public class AssemblyMover : MonoBehaviour {
	public GameObject toMove;
	public bool move=true;
	[Range(-0.1f,-0.009f)]
	public float speed=-0.009f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
		
			if (toMove) {
				toMove.transform.position += new Vector3(speed,0,0);
				transform.position += new Vector3(speed,0,0);
			}
		}

	}

	void stopMoving()
	{
		move = false;
	}
}
