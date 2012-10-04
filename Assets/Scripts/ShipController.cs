using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetAxis("Horizontal")) > 0)
		{
			//right
		}
		
		if ((Input.GetAxis("Horizontal")) < 0)
		{
			//left
		}
		
		if ((Input.GetAxis("Horizontal")) == 0)
		{
			//none
			//turn off effects
		}
		
		if ((Input.GetAxis("Vertical")) > 0)
		{
			//up
		}
		
		if ((Input.GetAxis("Vertical")) < 0)
		{
			//down
		}
		
		if ((Input.GetAxis("Vertical")) == 0)
		{
			//none, turn off effects
		}
		
		//constantly move the avatar based on position
		
		
	}
}
