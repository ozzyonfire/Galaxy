// the particles gameobject
public var particles:GameObject;

// the particles animator component
private var particleAnimator:ParticleAnimator;

// colours for each type of pickup
public var type1:Color[];
public var type2:Color[];
public var type3:Color[];

public var colorType1 : Color;
public var colorType2 : Color;
public var colorType3 : Color;

public var model : GameObject;

// variable to hold the type
public var type:int;

// min and max times for type change
public var minTypeChange:int = 10;
public var maxTypeChange:int = 30;

// min and max rotation speeds
public var minRotationSpeed:float = 0.5;
public var maxRotationSpeed:float = 2.0;

// calculated rotation speed
private var rotationSpeed:float;


function Awake()
{
	// calculate a random rotation speed 
	rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
	
	// retrieve the particle animator Component from the particles
	particleAnimator = particles.GetComponent(ParticleAnimator);
	
	// set a random type to begin
	SwapType();
}

function Start()
{
	while (true)
	{
		// wait for X seconds
		yield WaitForSeconds(Random.Range(minTypeChange, maxTypeChange));
		
		// set a random type
		SwapType();
	}
}

function Update () 
{
	// rotate the gameobject every frame
	transform.Rotate(rotationSpeed, rotationSpeed, 0);
	
	// rotate the particles every frame (so they rotate at twice the speed of the whole object)
	particles.transform.Rotate(rotationSpeed, rotationSpeed, 0);
}

function SwapType()
{
	// generate a random number between 1 and 10
	var random:float = Random.Range(1,11);
	
	// set the type
	if (random <= 5) // 50% for type 1
	{
		type = 1;
		//particleAnimator.colorAnimation = type1;
		model.renderer.material.color = colorType1;
	}
	else if (random <= 8) // 30% for type 2
	{
		type = 2;
		//particleAnimator.colorAnimation = type2;
		model.renderer.material.color = colorType2;
	}
	else // // 20% for type 3
	{
		type = 3;
		//particleAnimator.colorAnimation = type3;
		model.renderer.material.color = colorType3;
	}
}