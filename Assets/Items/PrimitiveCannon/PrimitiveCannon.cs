using UnityEngine;
using System.Collections;

public class PrimitiveCannon : MonoBehaviour,Item {

	public int clip;
	public GameObject[] bullets;
	public Transform ShootPosition;

	// Use this for initialization
	void Start () 
	{

	}

	public void UseOnce()
	{
		if(clip > 0)
		{
			clip --;
			GameObject currentBullet = bullets[Random.Range(0,2)];
			currentBullet = SimplePool.Spawn(currentBullet,ShootPosition.transform.position,Quaternion.identity);
			print(this.transform.position+ShootPosition.transform.forward);
			Rigidbody bulletRigid = currentBullet.GetComponent<Rigidbody>();
			bulletRigid.AddForce(ShootPosition.transform.forward * 1000.0f,ForceMode.Acceleration);
			//currentBullet.transform.parent = 
		}
	}

	public void Reload()
	{
		clip = 20;
	}

	public string getType()
	{
		return "gun";
	}
}
