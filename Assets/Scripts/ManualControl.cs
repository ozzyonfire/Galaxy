using UnityEngine;
using System.Collections;

public class ManualControl : MonoBehaviour {
	
	private float keyboardSpeed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () {
		float X = Input.GetAxis("Horizontal") * keyboardSpeed * Time.deltaTime;
		float Y = Input.GetAxis("Vertical") * keyboardSpeed * Time.deltaTime;
		float Z = 0;
		if (Input.GetKey("z"))
		{
			Z = Input.GetAxis("Vertical") * keyboardSpeed * Time.deltaTime;
			X = Input.GetAxis("Horizontal") * keyboardSpeed * Time.deltaTime;
			Y = 0;
		}
		
		Vector3 newPos = new Vector3(0,0,0);
		newPos = rigidbody.position + new Vector3(X,Y,Z);
		rigidbody.MovePosition(newPos);
	}
}
