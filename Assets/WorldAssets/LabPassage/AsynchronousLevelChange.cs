using UnityEngine;
using System.Collections;

public class AsynchronousLevelChange : MonoBehaviour {

	public string levelName;
	public bool buttonNeeded;

	GameObject player;
	GameObject leftTarget;
	GameObject rightTarget;

	Collider playerCollider;

	void Start()
	{
		player = GameObject.Find("Player");
		leftTarget = GameObject.Find ("LeftTarget");
		rightTarget = GameObject.Find ("RightTarget");
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.P))
		{
			Application.LoadLevelAsync(levelName);
		}
		//print("IsChildOf: " + GameObject.Find ("LeftTarget").transform.IsChildOf(GameObject.Find("Player").transform));
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerCollider = other;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			playerCollider = other;
		}
	}

	void ChangeButtonState(bool value)
	{
		buttonNeeded = value;
		ChangeLevel();
	}

	void ChangeLevel()
	{
		playerCollider.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if(leftTarget.transform.IsChildOf(player.transform) == true && rightTarget.transform.IsChildOf(player.transform) == true)
		{
			if(buttonNeeded)
			{
				Application.LoadLevelAsync(levelName);
			}
		}
	}
}
