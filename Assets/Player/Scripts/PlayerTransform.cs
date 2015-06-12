using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {

	private bool positioned = false;
	//private bool parenting = false;
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
	}

	void Update()
	{
		if(GameObject.Find("Player") != null && !positioned)
		{

			player.transform.localPosition = Vector3.zero;
			player.transform.position = Vector3.zero;
			player.transform.parent = null;
			player.transform.localScale = Vector3.one;
			//print ("Player found");
			//player.transform.localPosition = Vector3.zero;
			//player.transform.position = this.transform.position;
			//player.transform.rotation = this.transform.rotation;
			if(player.transform.GetChild(2).name == "Blobb")
			{
				player.transform.GetChild(2).transform.position = this.transform.position;
				player.transform.GetChild(2).transform.rotation = this.transform.rotation;
			}
			//print(player.transform.GetChild(2));

			// Damit das Parenting geht muss der SpawnPoint so positioniert sein , das der Blobb in keinem Objekt landen kann
			/*if(!parenting && transform.parent != null)
			{
				print ("Player before Parent");
				//player.transform.position = this.transform.localPosition;
				//player.transform.rotation = this.transform.localRotation;
				player.transform.parent = this.transform.parent;
				//player.transform.SetParent(this.transform.parent, false);

				print ("Player after Parent");
				parenting = true;
			}*/

			positioned = true;
		}
	}
}
