// HUBelements
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	// For our timer we will use minutes and seconds
	public float Seconds = 59;
	public float Minutes = 0;
	// Variables used for the player's health, update value upon collision
	public int curHP=100;
	public float curScore = 0;
	public float powerTimer = 0;

	
	void OnGUI(){
		//GUI.Box (new Rect (0,0,100,50), "Time: " + Minutes.ToString("f0") + ":" + Seconds.ToString("f0"));
		GUI.Box (new Rect (Screen.width - 100,0,100,50), "Score: " + curScore.ToString ("f0"));
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Health: " + curHP.ToString ("f0"));
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Power Time: " + powerTimer.ToString("f0"));
	
		//#####################################################################################
		// Timer Code:
		// This is if statement checks how many seconds there are to decide what to do.
		// If there are more than 0 seconds it will continue to countdown.
		// If not then it will reset the amount of seconds to 59 and handle the minutes;
		// Handling the minutes is very similar to handling the seconds.
		if(Seconds <= 0)
		{
			Seconds = 59;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				// This makes the guiText show the time as X:XX. ToString.("f0") formats it so there is no decimal place.
				GUI.Box (new Rect (0,0,100,50), "Time: " + Minutes.ToString("f0") + ":0" + Seconds.ToString("f0"));
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}
		
		// These lines will make sure the time is shown as X:XX and not X:XX.XXXXXX
		if(Mathf.Round(Seconds) <= 9)
		{
			GUI.Box (new Rect (0,0,100,50), "Time: " + Minutes.ToString("f0") + ":0" + Seconds.ToString("f0"));
		}
		else
		{
			GUI.Box (new Rect (0,0,100,50), "Time: " + Minutes.ToString("f0") + ":" + Seconds.ToString("f0"));
		}
		//End of time code
		//#####################################################################################
				
	}

}