using UnityEngine;
using System.Collections;

public class PrimitiveCannon : MonoBehaviour,Item {

	public int clip;
	int maxClip;
	public GameObject[] bullets;
	public Transform ShootPosition;
	public GameObject laserPointer;

	// Use this for initialization
	void Start () 
	{
		maxClip = clip;
	}

	public void UseOnce()
	{
		//print("UseOnce() called from "+this.name);
		if(clip > 0)
		{
			//clip --;
			// TODO: 
			GameObject currentBullet = bullets[Random.Range(0,2)];
			currentBullet = SimplePool.Spawn(currentBullet,ShootPosition.transform.position,Quaternion.identity);
			//print(this.transform.position+ShootPosition.transform.forward);
			Rigidbody bulletRigid = currentBullet.GetComponent<Rigidbody>();
			bulletRigid.AddForce(ShootPosition.transform.forward * 1500.0f,ForceMode.Acceleration);
			//currentBullet.transform.parent = 
		}
	}

	public void Reload()
	{
		clip = maxClip;
	}

	public void OnEquip()
	{
		laserPointer.SetActive(true);
	}

	public void OnDeequip()
	{
		laserPointer.SetActive(false);
	}

	public string getType()
	{
		return "gun";
	}
}
