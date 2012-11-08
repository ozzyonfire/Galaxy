using UnityEngine;
using System.Collections;
 
public class camControl : MonoBehaviour {
 
 void Update () {
  if(Input.GetKey("1")){
   Debug.Log("Using Camera One");
   camSwap(1);
  }
  if(Input.GetKey("2")){
   Debug.Log("Using Camera Two");
   camSwap(2);
  }
  if(Input.GetKey("3")){
   Debug.Log("Using Camera Three");
   camSwap(3);
  }
 }
 
 void camSwap(int currentCam){
  GameObject[] cameras = GameObject.FindGameObjectsWithTag("cam");
 
  foreach (GameObject cams in cameras){
   Camera theCam = cams.GetComponent<Camera>() as Camera;
   theCam.enabled = false;
  }  
 
  string oneToUse = "Camera"+currentCam;
  Camera usedCam = GameObject.Find(oneToUse).GetComponent<Camera>() as Camera;
  usedCam.enabled = true;
 }
}