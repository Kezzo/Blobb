using UnityEngine;
using System.Collections;

public class CameraRaycast : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider.name == "Activator")
			{
				Transform parent = hit.collider.transform.parent.FindChild("Spawner");
				parent.BroadcastMessage("SetActiveStatus", true, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
