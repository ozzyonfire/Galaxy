using UnityEngine;
using System.Collections;
 
public class camControl : MonoBehaviour
{
	
	public GameObject[] cameras;
	
	void Update ()
	{
		if (Input.GetKey ("1")) {
			Debug.Log ("Using Camera One");
			cameras [1].GetComponent<Camera> ().enabled = true;
			cameras [0].GetComponent<Camera> ().enabled = true;
			cameras [2].GetComponent<Camera> ().enabled = false;
			cameras [0].GetComponent<Camera> ().rect = new Rect(0,0,1,1);
		}
		if (Input.GetKey ("2")) {
			cameras [1].GetComponent<Camera> ().enabled = false;
			cameras [0].GetComponent<Camera> ().enabled = true;
			cameras [2].GetComponent<Camera> ().enabled = true;
			cameras [0].GetComponent<Camera> ().rect = new Rect(0,0,1,1);
		}
		if (Input.GetKey ("3")) {
			cameras [1].GetComponent<Camera> ().enabled = true;
			cameras [0].GetComponent<Camera> ().enabled = true;
			cameras [2].GetComponent<Camera> ().enabled = true;
			cameras [0].GetComponent<Camera> ().rect = new Rect(0,0,0.75f,1);
		}
		if (Input.GetKey ("4")) {
			cameras [1].GetComponent<Camera> ().enabled = false;
			cameras [0].GetComponent<Camera> ().enabled = true;
			cameras [2].GetComponent<Camera> ().enabled = false;
			cameras [0].GetComponent<Camera> ().rect = new Rect(0,0,1,1);
		}
	}
}