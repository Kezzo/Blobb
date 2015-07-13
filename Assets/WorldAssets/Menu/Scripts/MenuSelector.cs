using UnityEngine;
using System.Collections;

public class MenuSelector : MonoBehaviour {

	public GameObject keybindsUi;

	RaycastHit hit;
	GameObject lastHitItem;
	GameManagement manager;

	SixenseInput.Controller hydraLeft;
	SixenseInput.Controller hydraRight;


	string buttonHighlited;

	void Start()
	{
		manager = GameObject.Find("GameManager").GetComponent<GameManagement>();
	}

	void Update()
	{
		hydraRight = SixenseInput.Controllers[1];
		hydraLeft = SixenseInput.Controllers[0];

		if(hydraLeft.GetButtonDown(SixenseButtons.TRIGGER) || hydraRight.GetButtonDown(SixenseButtons.TRIGGER))
		{
			if(buttonHighlited == "StartTut")
			{
				Application.LoadLevelAsync("Level_00");
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "StartHub")
			{
				Application.LoadLevelAsync("hub");
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "PiratesPart1")
			{
				Application.LoadLevelAsync("pirates");
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "PiratesSchiebe")
			{
				Application.LoadLevelAsync("SchiebeRätselPart1");
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "PiratesDark")
			{
				Application.LoadLevelAsync("BelowTheDeck");
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "PiratesPart2")
			{
				Application.LoadLevelAsync("pirates");
				manager.pirateLevelPartTwo = true;
				keybindsUi.SetActive(true);
				this.GetComponentInParent<FadeOutOnLevelLoad>().fade(0.0f);
			}
			else if(buttonHighlited == "PiratesSchiebe2")
			{
				Application.LoadLevelAsync("SchieberätselPart2");
				keybindsUi.SetActive(true);
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
					lastHitItem.GetComponent<MeshRenderer>().material.color = new Color(108.0f/255.0f,171.0f/255.0f,50.0f/255.0f);

				}
			}
			lastHitItem = hitItem;
		}
	}
}
