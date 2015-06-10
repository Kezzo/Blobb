using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {

	private bool positioned = false;
	private bool parenting = false;

	void Update()
	{
		if(MakePlayerPersistent.publicPlayerInstance != null && !positioned)
		{
			//GameObject player = MakePlayerPersistent.publicPlayerInstance.gameObject;
			GameObject player = GameObject.Find("Player");
			//print ("Player found");
			//player.transform.localPosition = Vector3.zero;
			player.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			player.transform.rotation = this.transform.rotation;

			// Damit das Parenting geht muss der SpawnPoint so positioniert sein , das der Blobb in keinem Objekt landen kann
			if(!parenting && transform.parent != null)
			{
				player.transform.parent = this.transform.parent;
				parenting = true;
			}

			positioned = true;
		}
	}
}
