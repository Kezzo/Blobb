using UnityEngine;
using System.Collections;

public class PassageChange : MonoBehaviour {

	private bool statuePassaging = false;
	public bool staging = true;

	void ReturnHub(bool value)
	{
		print("Value: " + value);
		statuePassaging = value;

		StatuePosition();

		print("ReturnHub");
	}

	void StatuePosition()
	{
		print (statuePassaging);
		if(statuePassaging == true)
		{
			
			GameObject.Find("Statue_Passage").transform.position = new Vector3(-0.03f, 7.46f, 29.83f);
			print ("done");
			staging = false;
		}
		print("StatuePosition");
		print (transform.position);
	}
}
