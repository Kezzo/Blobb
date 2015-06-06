using UnityEngine;
using System.Collections;

public class CraneMover : MonoBehaviour {
	public float distance=150;
	[Range(0.001f,0.6f)]
	public float speed=0.1f;
    float timemultiplier=0.01f;
	float i;
	public float height=100;
	float ascend;
	bool arrived=false;
	public GameObject container;
	public GameObject groundplate;
	public GameObject glassplate;
	public GameObject ropeA;
	public GameObject ropeB;
	public GameObject player;
	float cooldown=0.5f;
	// Use this for initialization
	void Start () {
		 i = distance;
		ascend = height;
	}
	
	// Update is called once per frame
	void Update () {
		//print (distance / Time.deltaTime * speed);

		if (i > 0) {
			float travelled = speed / Time.deltaTime * timemultiplier;
			this.transform.position += new Vector3 (0, 0, travelled);
			i -= travelled;
			//print (i);
		}

		if (i <= 0.0f) {

			if(container)
			{//groundplate.transform.position = Vector3.Lerp(groundplate.transform.position, new Vector3(0.0f,1.0f, 0.0f), Time.deltaTime);
				if(height>0)
				{
					container.transform.position += new Vector3(0,-0.025f,0);
					groundplate.transform.position += new Vector3(0,-0.025f,0);
					ropeA.transform.position += new Vector3(0,-0.0125f,0);
					ropeA.transform.localScale += new Vector3(0,0.0125f,0);
					ropeB.transform.position += new Vector3(0,-0.0125f,0);
					ropeB.transform.localScale += new Vector3(0,0.0125f,0);
					height--;}

			}
			if (height<=0){

				
				cooldown -= Time.deltaTime;

				//print("cooldown: "+cooldown);
				
				if(cooldown < 0.0f)
				{
					arrived=true;
					
				}

						
					}

			if (arrived==true){

				print("ascend");
				groundplate.layer=11;
				glassplate.layer=11;

				player.transform.parent=null;
				if(ascend>0)
				{

					container.transform.position += new Vector3(0,0.025f,0);
					ropeA.transform.position += new Vector3(0,0.0125f,0);
					ropeA.transform.localScale += new Vector3(0,-0.0125f,0);
					ropeB.transform.position += new Vector3(0,0.0125f,0);
					ropeB.transform.localScale += new Vector3(0,-0.0125f,0);
					ascend--;}
			}


		}
	}

}
