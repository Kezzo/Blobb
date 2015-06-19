using UnityEngine;
using System.Collections;

public class AssemblyMover : MonoBehaviour {
	public GameObject toMove;
	public bool move=true;
	[Range(-0.1f,-0.009f)]
	public float speed=-0.009f;
	public float distancePerStep=0.1f;
	float counter=1.0f;
	bool movePlayer=true;
	Vector3 startPos;
	Vector3 sphereStartPos;
	Vector3 sphereUpStartPos;
	public float delay = 0;
	public GameObject sphereblobb;
	public GameObject sphereblobbUp;
	bool moveUp=false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		if (sphereblobb) {
			sphereStartPos=sphereblobb.transform.position;
		}
		if (sphereblobbUp) {
			sphereUpStartPos=sphereblobbUp.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
		
			if (toMove) {
				/*
				toMove.transform.position += new Vector3(speed,0,0);
				transform.position += new Vector3(speed,0,0);
				*/
				delay-=Time.deltaTime;
				if(delay<0){
					moveUp=false;
					sphereblobb.SetActive(false);
					sphereblobbUp.SetActive(false);
					counter-=Time.deltaTime;
					if(counter>0){
						if (movePlayer==true){
							Vector3 nextStep = transform.position+ new Vector3(-distancePerStep,0,0);
							transform.position = Vector3.Lerp(transform.position,nextStep , 10);
							
						}
						
					}
					if (counter<0){
						counter=1.0f;
						movePlayer=!movePlayer;
					}
				}
				if(sphereblobbUp){
					if(moveUp==true){
						sphereblobbUp.transform.position = Vector3.Lerp(sphereblobbUp.transform.position,sphereblobbUp.transform.position+ new Vector3(0,0.2f,0) , 5);

					}

				}







			}
		}

	}

	void stopMoving()
	{
		move = false;
	}

	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		if(toMove == null && other.name.Contains("Blobb"))
		{
			toMove = other.transform.root.gameObject;
		}

		if (other.name.Contains ("finishbox")) {
			transform.position=startPos;
			delay=4;
			sphereblobb.SetActive(true);
			sphereblobb.transform.position=sphereStartPos;

			sphereblobbUp.SetActive(true);
			sphereblobbUp.transform.position=sphereUpStartPos;
			moveUp=true;
		}
	
	}
}
