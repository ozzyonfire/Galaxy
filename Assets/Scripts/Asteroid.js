#pragma strict
 var x: int;
 var y: int;
 var xPostion: int;
 var yPostion: int;
 var count: int=0;
 var time:long;
 time=Time.time;
 count=0;
private var cam : Camera;
private var planes : Plane[];

 var spawn : GameObject;

function Start() {
   
   /**The first asteroid will try to find the empty object and repostion it self to spawn from that point
   	WARNING!!!: YOU SHOULD CHANGE THE CUBE NAME TO WHATEVER YOU NAME YOUR EMPTY OBJECT
   	*/
   var postions:GameObject = spawn;
   //xPostion=postions.transform.position.x;
   yPostion=Screen.height;
   
   //this is the postion of the x axis ( -20 and + 20 of the postion of the empty objects)
   xPostion=Random.Range(0,Screen.width);
   
   //this controls the speed and direction of the asteroid
   x=Random.value*100-1;
   y=Random.value*-100-80;
    
	
	var newPos: Vector3; newPos = new Vector3(xPostion,yPostion,0); 
	gameObject.transform.position=newPos;
	gameObject.transform.rigidbody.AddForce(x,y,0);
	
	
	
	

}

function OnCollisionEnter(hitInfo : Collision)
{
	//var x = hitInfo.relativeVelocity.x;
	//var y = hitInfo.relativeVelocity.y;
			
	//gameObject.transform.rigidbody.velocity = Vector3.zero;
	//gameObject.transform.rigidbody.angularVelocity = Vector3.zero;
	
	//gameObject.transform.rigidbody.AddForce(50,50, 0);
}

				
function Update () {
					
					 var p:Vector3=gameObject.transform.position;
					 var viewPos : Vector3 = Camera.main.WorldToViewportPoint (p);
				    // the if condtion checks if the asteroid is out of the camera bound
				    if( !gameObject.renderer.isVisible )
				    {
						  
						 /**This is the same as the above function which looks for the empty object and repostion it
						 	with different speed
						 	WARNING!!!: YOU SHOULD CHANGE THE CUBE NAME TO WHATEVER YOU NAME YOUR EMPTY OBJECT
						 	*/ 
						 var postions:GameObject=spawn;
					  	 //xPostion=postions.transform.position.x;
					  	 yPostion=postions.transform.position.y;
					   	 xPostion=Random.Range(0,Screen.width);
					     
					     
						 var newPos: Vector3; newPos = new Vector3(xPostion,yPostion,0); 
						 gameObject.transform.position=newPos;
						 
		
					    gameObject.transform.rigidbody.velocity = Vector3.zero;
						gameObject.transform.rigidbody.angularVelocity = Vector3.zero;
						x=Random.value*100-1;
						y=Random.value*-100-80;		
						gameObject.transform.rigidbody.AddForce(x,y,0);
				    }
}