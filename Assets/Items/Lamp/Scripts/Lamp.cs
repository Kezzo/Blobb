using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour,Item  {

	public Light spotlight;

	Material volumetricLight;

	bool flickering = false;
	float timeToStartFlickering;
	float flickeringTime;

	Vector3 positionLastFrame;
	Vector3 positionNow;
	int shakeCounter;

	bool equipped = false;
	bool weakLight = false;

	void Start () 
	{
		timeToStartFlickering = 3.0f;
		flickeringTime = 2.0f;
		volumetricLight = spotlight.gameObject.transform.FindChild("lightCone").gameObject.GetComponent<MeshRenderer>().material;
	}

	void Update () 
	{

		positionNow = this.transform.position;
		if(spotlight.enabled)
		{
			if (timeToStartFlickering > 0.0f) 
			{
				timeToStartFlickering -= Time.deltaTime;
			} 
			else if(!weakLight)
			{
				flickering = true;
			}

			if(flickering)
			{
				if(flickeringTime > 0.0f)
				{
					flickeringTime -= Time.deltaTime;
					spotlight.intensity = Random.Range(2.0f,5.0f);

				}
				else
				{
					flickering = false;
					weakLight = true;
				}
			}
			else if(weakLight)
			{
				spotlight.intensity = Random.Range(0.0f,1.0f);
			}
			print (spotlight.intensity+"+"+volumetricLight.color.a);
			volumetricLight.SetFloat("_Metallic", 1.0f - spotlight.intensity / 8.0f);
		}

		if(equipped)
		{
			if(Mathf.Abs(positionNow.x + positionNow.y + positionNow.z - positionLastFrame.x - positionLastFrame.y - positionLastFrame.z) > .05f)
			{
				shakeCounter++;

				if(shakeCounter > 30)
				{
					print ("Shake");
					flickering = false;
					weakLight = false;
					flickeringTime = Random.Range(5.0f,10.0f);
					timeToStartFlickering = Random.Range(10.0f,20.0f);
					shakeCounter = 0;
					spotlight.intensity = 8.0f;
				}
			}
			else if(shakeCounter < 0)
			{
				shakeCounter--;
			}

		}

		positionLastFrame = positionNow;
	}

	public void UseOnce()
	{
		spotlight.enabled = !spotlight.enabled;
	}

	public void Reload()
	{
	}
	
	public void OnEquip()
	{
		equipped = true;
	}
	public void OnDeequip()
	{
		equipped = false;
	}

	public string getType()
	{
		return "Lamp";
	}
}
