using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {
	public enum enDirection {X,Y}
	public float speed;
	public float distance;
	public enDirection direction;
	
	Vector3 startPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		startPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 distanceTravelled = gameObject.transform.position - startPosition;
		if (distanceTravelled.magnitude > distance)
		{
			// gone too far switch directions
			speed = speed*-1;
		}
			
		// changes the position of the object by the speed
		switch(direction)
		{
			case enDirection.X:
				gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, 
					gameObject.transform.position.y, 
					gameObject.transform.position.z);
			break;
			case enDirection.Y:
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
					gameObject.transform.position.y + speed, 
					gameObject.transform.position.z);
			break;
		}
			
	}
}
