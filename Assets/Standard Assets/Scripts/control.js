/** use this for the object that will control the spawn of the asteroids
	this script should be attached to an empty object which is centered in the top middle of the screen
	it should still be inside the screen but it should be on the edge of the screen.
	if the Camera is moving then you should attach the object to move with it so it won't be left behind.
	
	Info: this script repostion every asteroid once it leaves the vision of the camera
	*/


#pragma strict
 var time:long;
 time=Time.time;
 var x: int;
 var y: int;
 var xPostion: int;
 var yPostion:int;
 static var astroids: ArrayList;
 static var start: boolean=true;
 var asteroid : GameObject;
 var NumberOfAsteroids : int;
 
function Start () {
	
	

}

function Update () {

		
	if(start)
	{
		print("starting");
		/**Number of asteroids to be in the map it's 1+ the length of the loop which is 4 here
			the 1 is the orginal asteroid and the 4 is the number of clones
			*/
		for(var i: int = 0; i < NumberOfAsteroids - 1 ;i++)
		{
		/**this finds the orginal asteroid and clone it
			when you create the asteroid you should name it the same name that is shown in the find function which is "asteroid"
			*/
		var postions:GameObject=asteroid;
			 
		 xPostion=postions.transform.position.x;
		 yPostion=postions.transform.position.y;
		 //this is the postion of the x axis ( -20 and + 20 of the postion of the empty objects that this script is attached to
		 xPostion=Random.Range(xPostion-10,xPostion+10);
		
		 
		 var newPos: Vector3; newPos = new Vector3(xPostion,yPostion,0); 
		 //gameObject.transform.position=newPos;
			asteroid.transform.position=newPos;
			Instantiate(asteroid, asteroid.transform.position, asteroid.transform.rotation);
			
		}
			start=false;
			
		
	}
}

function clearAsteroids()
{
print ("clearing");
	var asteroids : GameObject[] = GameObject.FindGameObjectsWithTag("Asteroid");	
	for (var i : int = 0; i < asteroids.length-1; i++)
	{
		GameObject.Destroy(asteroids[i]);
	}
}

function startAsteroids()
{
	start = true;
}