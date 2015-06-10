using UnityEngine;
using System.Collections;

public class Lore : MonoBehaviour {

	public Transform rift;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
		if(rift.transform.localEulerAngles.z > 180.0f)
		{
			this.transform.Translate(Vector3.right *Time.deltaTime * 15.0f * (1.0f - rift.transform.localEulerAngles.z/360));
		}
		else if(rift.transform.localEulerAngles.z > 0.0f)
		{
			this.transform.Translate(Vector3.left * Time.deltaTime * 15.0f * rift.transform.localEulerAngles.z/360.0f);
		}

	}
}
