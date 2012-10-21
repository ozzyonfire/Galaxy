using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {
	public float speedX;
	public float speedY;
	public float speedZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(speedX, speedY, speedZ);
	}
}
