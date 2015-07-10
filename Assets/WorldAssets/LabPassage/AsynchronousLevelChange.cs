using UnityEngine;
using System.Collections;

public class AsynchronousLevelChange : MonoBehaviour {

	public string levelName;
	public bool buttonNeeded;

	private bool buttonActionDetected = false;

	//private AsyncOperation asyncLoader;
	//private bool loadingFinished = false;

	private bool doOnce = false;

	private GameObject player;
	private GameObject leftTarget;
	private GameObject rightTarget;

	private Collider playerCollider;

	void Start()
	{

		player = GameObject.Find("Player");
		leftTarget = GameObject.Find ("LeftTarget");
		rightTarget = GameObject.Find ("RightTarget");
		//StartCoroutine(Load());
		//asyncLoader.allowSceneActivation = false;
		//Application.backgroundLoadingPriority = ThreadPriority.Low;

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerCollider = other;
			ChangeLevel();
		}

		if(other.name == "MovingBlock" || other.name == "boat")
		{
			ChangeLevel();
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
		buttonActionDetected = value;
		ChangeLevel();
	}

	void ChangeLevel()
	{
		print ("ChangeLevel: Done");
		if(leftTarget.transform.IsChildOf(player.transform) == true && rightTarget.transform.IsChildOf(player.transform) == true)
		{
			if(buttonNeeded)
			{
				if(buttonActionDetected)
				{
					player.transform.parent = null;
					Application.LoadLevelAsync(levelName);
					player.GetComponentInChildren<FadeOutOnLevelLoad>().fade(0.0f);
					/*if(loadingFinished)
					{
						Application.LoadLevelAsync(levelName);
						//asyncLoader.allowSceneActivation = true;
					}*/
				}
			}
			else
			{
				player.transform.parent = null;
				Application.LoadLevelAsync(levelName);
				player.GetComponentInChildren<FadeOutOnLevelLoad>().fade(0.0f);
				/*if(loadingFinished)
				{
					Application.LoadLevelAsync(levelName);
					//asyncLoader.allowSceneActivation = true;
				}*/
			}
		}
	}

	/*IEnumerator Load()
	{
			asyncLoader = Application.LoadLevelAsync(levelName);
			while(!asyncLoader.isDone){
				if(asyncLoader.progress >= 0.9f){
					asyncLoader.allowSceneActivation = false;
					loadingFinished = true;
					break;
				}
				yield return 0;
			}
			yield return asyncLoader;
	}*/
}
