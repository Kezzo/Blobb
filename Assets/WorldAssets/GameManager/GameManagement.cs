using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour {

	private static GameManagement privateGameManagerInstance;
	
	public static GameManagement publicPGameManagerInstance
	{
		get
		{
			if(privateGameManagerInstance == null)
			{
				//Das erste Mal, wenn diese Referenz genutzt wird,
				// wird das Objekt aus der Szene geholt
				privateGameManagerInstance = GameObject.FindObjectOfType<GameManagement>();
				DontDestroyOnLoad(privateGameManagerInstance.gameObject);
			}
			
			return privateGameManagerInstance;
		}
	}
	
	void Awake() 
	{
		if(privateGameManagerInstance == null)
		{
			//Wenn es sich um die erste Instanz handelt, 
			// wird es zum Singleton ernannt
			privateGameManagerInstance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//Wenn es schon ein Singleton gibt, aber ein weiteres
			// Objekt gefunden wird, wird dieses gelöscht
			if(this != privateGameManagerInstance)
			{
				Destroy(this.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
		Application.LoadLevel(1);
	}

	void OnApplicationQuit()
	{
		Destroy(this.gameObject);
	}

}
