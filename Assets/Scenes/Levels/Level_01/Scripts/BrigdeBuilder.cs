using UnityEngine;
using System.Collections;

public class BrigdeBuilder : MonoBehaviour {

	public GameObject bridge;
	public GameObject bumper; 
	bool movingBridge = false;
	float step;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (movingBridge == true) {
			step = 3 * Time.deltaTime;
			Vector3 bridgeTarget = new Vector3 (-1.77f,3.38f,14.02f);
			Vector3 bumperTarget = new Vector3(-1.15f,0.83f,9.46f);
			Vector3 parentPos = transform.parent.transform.position;

			bridge.transform.position = Vector3.MoveTowards(bridge.transform.position, bridgeTarget + parentPos, step); 
			bumper.transform.position = Vector3.MoveTowards(bumper.transform.position, bumperTarget + parentPos, step); 
		}
	
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "ThrowingBall(Clone)") 
		{
			movingBridge = true;

		}
	}
}
