using UnityEngine;
using System.Collections;

public class FadeOutOnLevelLoad : MonoBehaviour 
{

	public Material planeMat;

	bool isDark = false;
	float timeUntilNotDark = 2.0f;
	float darknessValue = 1.0f;

	void Update()
	{
		if(isDark)
		{
			timeUntilNotDark -= Time.deltaTime;
			if(timeUntilNotDark < 0.0f)
			{
				darknessValue -= Time.deltaTime;
				fade (darknessValue);
				if(darknessValue <= 0.0f)
				{
					timeUntilNotDark = 2.0f;
					darknessValue = 1.0f;
					isDark = false;
				}

			}
		}
	}

	public void fade(float howDark)
	{
		print ("FADE");
		if(isDark)
		{
			planeMat.color = new Color(0,0,0,howDark);
		}
		else
		{
			planeMat.color = new Color(0,0,0,1);
			isDark = true;
		}
	}
}
