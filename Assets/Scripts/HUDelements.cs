using UnityEngine;
using System.Collections;

public class HUDelements : MonoBehaviour {

	// For our timer we will use minutes and seconds
	public float Seconds = 59;
	public float Minutes = 0;
	// Variables used for the player's health, update value upon collision
	public float curHP=100;
	public float curScore = 0;
	
	public float powerTimer = 0;
	
	//for navigation setting
	public Vector3 screenVec;
	public float tarAngle;
	public Texture2D bigCircle;
	public Texture2D ptr;
	public Rect r;
	public Vector2 p;

	public GameObject player;
	public GameObject platform;
	public GameObject arrow;
	
	
	void OnGUI(){
		GUI.Box (new Rect (0,0,100,50), Minutes.ToString("f0") + ":" + Seconds.ToString("f0"));
		GUI.Box (new Rect (Screen.width - 100,0,100,50), curScore.ToString ("f0"));
		GUI.Box (new Rect (0,Screen.height - 50,100,50), curHP.ToString ("f0") + " %");
		GUI.Box (new Rect (Screen.width/2 - 50,Screen.height - 50,100,50), "Power Time: " + powerTimer.ToString("f0"));
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Navigation ");
		
		//##############################
		// Navigation Code:
		//r.Set (Screen.width - 100,Screen.height - 100,75,75); // rect where to draw compass)
		//GUI.DrawTexture(r, bigCircle); // draw the compass...
		//p.Set(r.x+r.width/2,r.y+r.height/2);// find the center
		//Matrix4x4 svMat = GUI.matrix;
		
		//screenVec.Set(platform.rigidbody.position.x - player.rigidbody.position.x, 
		//	platform.rigidbody.position.y - player.rigidbody.position.y,
		//	0);
		//screenVec.Set(Screen.width/2-Input.mousePosition.x,Screen.height/2 - Input.mousePosition.y, 0);
		
		
		
		//screenVec.Set(direction.x, direction.y, direction.z);

    	//tarAngle= (Mathf.Atan2(screenVec.y,screenVec.x) * Mathf.Rad2Deg)+90;
		//if (tarAngle < 0) tarAngle +=360;

   		//if (tarAngle != 0) transform.RotateAround(transform.position,transform.forward, -tarAngle);
		//print(tarAngle);
		
		//arrow.transform.RotateAround(new Vector3(1,0,0), tarAngle);
		//arrow.transform.TransformDirection(screenVec);
		
		//arrow.transform.rotation = Quaternion.LookRotation(direction);
		
		//GUIUtility.RotateAroundPivot(-tarAngle,p); // prepare matrix to rotate
	    //GUI.DrawTexture(r,ptr); // draw the needle rotated by angle
	    //GUI.matrix = svMat; // restore gui matrix
		//end of navigation code
		//##############################
		
	
		
		//##############################
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
				GUI.Box (new Rect (0,0,100,50), Minutes.ToString("f0") + ":0" + Seconds.ToString("f0"));
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}
		
		// These lines will make sure the time is shown as X:XX and not X:XX.XXXXXX
		if(Mathf.Round(Seconds) <= 9)
		{
			GUI.Box (new Rect (0,0,100,50), Minutes.ToString("f0") + ":0" + Seconds.ToString("f0"));
		}
		else
		{
			GUI.Box (new Rect (0,0,100,50), Minutes.ToString("f0") + ":" + Seconds.ToString("f0"));
		}
		//End of time code
		//#################################
				
	}
	
	void LateUpdate()
	{
		Vector3 direction = new Vector3(platform.transform.position.x - player.transform.position.x, 
			platform.transform.position.y - player.transform.position.y,
			platform.transform.position.z - player.transform.position.z);
		
		arrow.transform.LookAt( platform.transform.position );
	}
}
