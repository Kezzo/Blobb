using UnityEngine;
using System.Collections;

public class MakePlayerPersistent : MonoBehaviour 
{

	private static MakePlayerPersistent privatePlayerInstance;
	
	public static MakePlayerPersistent publicPlayerInstance
	{
		get
		{
			if(privatePlayerInstance == null)
			{
				//Das erste Mal, wenn diese Referenz genutzt wird,
				// wird das Objekt aus der Szene geholt
				privatePlayerInstance = GameObject.FindObjectOfType<MakePlayerPersistent>();
				DontDestroyOnLoad(privatePlayerInstance.gameObject);
			}
			
			return privatePlayerInstance;
		}
	}
	
	void Awake() 
	{
		if(privatePlayerInstance == null)
		{
			//Wenn es sich um die erste Instanz handelt, 
			// wird es zum Singleton ernannt
			privatePlayerInstance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//Wenn es schon ein Singleton gibt, aber ein weiteres
			// Objekt gefunden wird, wird dieses gelöscht
			if(this != privatePlayerInstance)
			{
				print ("Destroy on Awake");
				Destroy(this.gameObject);
			}
		}
	}

	void OnApplicationQuit()
	{
		print ("Destroy on Quit");
		Destroy(this.gameObject);
	}
}