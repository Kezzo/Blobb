using UnityEngine;
using System.Collections;

public class elevatorcontroll : Button {
	public GameObject door;
	public GameObject otherButton;
	public bool levelSwitchCheck;

	public bool status=false;
	public bool controller=true;

	// Update is called once per frame
	void Update () {
		if (controller == true) {
			if (status == true) {
				door.SendMessage("openDoor");
			}
			if (status == false) {
				door.SendMessage("closeDoor");
			}
		}

	}

	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		status = !status;
		otherButton.SendMessage ("changeStatus");
		if(levelSwitchCheck)
		{
			CheckForLevelSwitch();
		}
	}

	void changeStatus(){

		status = !status;
	}

	void CheckForLevelSwitch()
	{
		GameObject levelTrigger = GameObject.Find("LevelSwitchTrigger");
		if(levelTrigger != null)
		{
			levelTrigger.SendMessage("ChangeButtonState", true, SendMessageOptions.DontRequireReceiver);
		}
	}

}
