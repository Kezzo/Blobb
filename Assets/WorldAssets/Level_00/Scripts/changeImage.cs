using UnityEngine;
using System.Collections;

public class changeImage : MonoBehaviour {

	public Material imageA;
	public Material imageB;
	public Material imageC;
	MeshRenderer meshRenderer;
	Material[] materials;
	float counter=1.0f;
	bool changeMat=false;
	//bool thridMat=false;
	public int anzahl=2;
	int imageswitcher=1;
	// Use this for initialization
	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		materials = meshRenderer.materials;

	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if (counter < 0) {

		if (imageswitcher==1)
			{
				//print ("A ");
				materials[1] = imageA;
				meshRenderer.materials = materials;
				//changeMat=true;
				counter=1.0f;

			}


			if (imageswitcher==2)
			{
				//print ("B ");
				materials[1] = imageB;
				meshRenderer.materials = materials;
				//changeMat=false;
				counter=1.0f;
				
			}
			if (imageswitcher==3)
			{
				//print ("C ");
				materials[1] = imageC;
				meshRenderer.materials = materials;
				//changeMat=false;
				counter=1.0f;
				
			}
			changeMat =!changeMat;
			imageswitcher++;
			if(imageswitcher%anzahl==1)
			{
				imageswitcher=1;
			}

		}
	}
}
