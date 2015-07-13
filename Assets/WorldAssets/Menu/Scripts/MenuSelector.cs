using UnityEngine;
using System.Collections;

public class MenuSelector : MonoBehaviour {

	RaycastHit hit;
	GameObject lastHitItem;
	SixenseInput.Controller hydraLeft;
	SixenseInput.Controller hydraRight;

	string buttonHighlited;

	void Update()
	{
		hydraRight = SixenseInput.Controllers[1];
		hydraLeft = SixenseInput.Controllers[0];

		if(hydraLeft.GetButtonDown(SixenseButtons.TRIGGER) || hydraRight.GetButtonDown(SixenseButtons.TRIGGER))
		{
			if(buttonHighlited == "StartTut")
			{
				Application.LoadLevelAsync("Level_00");
				GameObject.Find("KeyBinds").SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "StartHub")
			{
				Application.LoadLevelAsync("hub");
				GameObject.Find("KeyBinds").SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "Exit")
			{
				Application.Quit();
			}
		}
	}

	void FixedUpdate ()
	{
		if(Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward),out hit,50))
		{
			GameObject hitItem = hit.collider.gameObject;
			if(hitItem.layer == 5)
			{
				hitItem.GetComponent<MeshRenderer>().material.color = Color.red;
				buttonHighlited = hitItem.transform.parent.name;
			}
			else
			{
				buttonHighlited = "";
			}
			if(hitItem != lastHitItem)
			{
				if(lastHitItem != null && lastHitItem.layer == 5)
				{
					lastHitItem.GetComponent<MeshRenderer>().material.color = Color.white;

				}
			}
			lastHitItem = hitItem;
		}
	}
}
