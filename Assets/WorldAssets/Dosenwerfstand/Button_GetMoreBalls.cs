using UnityEngine;
using System.Collections;

public class Button_GetMoreBalls : Button {

	public GameObject ball;

	public Transform rightPosition;
	public Transform leftPosition;
	
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		
		//spawnDosen();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update ();
	}
	
	protected override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		print ("OnTriggerEnter");
	}
	
	protected override void OnButtonActivation()
	{
		base.OnButtonActivation();
		print ("Button Activated");
		spawnBalls();
	}

	void spawnBalls()
	{
		for(int i=0; i<4; i++)
		{
			if(i%1 == 0 && i%3 == 0)
			{
				Instantiate(ball, rightPosition.position, Quaternion.identity);
			}
			else
			{
				Instantiate(ball, leftPosition.position, Quaternion.identity);
			}

		}

	}
}
