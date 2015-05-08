using UnityEngine;
using System.Collections;

public class WeaponSpawn : MonoBehaviour {

	public GameObject weaponsBox;
	public GameObject buttom;
	public GameObject top;
	public GameObject weapon;
	GameObject spawnObject;

	bool movingButtom = false;
	float step;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (movingButtom) {
			step = (3 * Time.deltaTime)/2;
			Vector3 buttomTarget = new Vector3 (-7.66f,-12.75f,12.52f);
			Vector3 parentPos = weaponsBox.transform.position;
			
			buttom.transform.position = Vector3.MoveTowards(buttom.transform.position, buttomTarget + parentPos, step); 

		}*/
	}

	void FixedUpdate(){
		if (movingButtom) {
			step = (3 * Time.deltaTime)/2;
			Vector3 buttomTarget = new Vector3 (-7.66f,-12.75f,12.52f);
			Vector3 parentPos = weaponsBox.transform.position;
			
			buttom.transform.position = Vector3.MoveTowards(buttom.transform.position, buttomTarget + parentPos, step); 
			
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "ThrowingBall(Clone)") 
		{
			Destroy(top);
			SpawnWeapon();
			movingButtom = true;
			
		}
	}

	void SpawnWeapon()
	{
		Vector3 spawnPoint = new Vector3 (38.4f,9.55f, 81.25f);
		spawnObject = (GameObject)Instantiate (weapon, spawnPoint, transform.rotation);
	}
}
