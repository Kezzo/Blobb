using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour,Item {

//	bool isArmed;

	//Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		//rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseOnce()
	{
		//isArmed = true;
	}
	public void Reload(){}
	public void OnEquip(){}
	public void OnDeequip()
	{
		//print(this.transform.parent.name);
		if(!this.transform.parent.name.Contains("Inventory"))
		{
			StartCoroutine(ExplodeAfter(3.0f));
		}

		//print ("Timer started!");
	}

	public IEnumerator ExplodeAfter(float secondsToWait)
	{
		//print ("IEnumerator started!");
		yield return new WaitForSeconds(secondsToWait);
		//print("Explode!");

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, 5.0f);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			
			if (rb != null)
				rb.AddExplosionForce(10.0f, explosionPos, 5.0f, 3.0f, ForceMode.Impulse);
			
		}
	}

	public string getType()
	{
		return "grenade";
	}
}
