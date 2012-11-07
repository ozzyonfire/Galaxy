using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//adding explosions
	public GameObject[] _shipExplosions;
	
	//game play variables
	private int health;
	private int score;
	
	public float playerSpeed = 20;
	public double collisionForce = 1.0;
	
	private GUITest guiScript;
	private KinectModelControllerV2 KScript;
	
	private GameObject HandLeft;
	private GameObject HandRight;
	
	public GameObject landingPad;
	public Color otherColor;
	
	private float powerTimer = 0.0f;
	public bool asteroidsCleared = false;

	// Use this for initialization
	void Start () {
		guiScript = Camera.main.GetComponent<GUITest>();
		KScript =  gameObject.GetComponent<KinectModelControllerV2>();
		HandLeft = KScript.Hand_Left;
		HandRight = KScript.Hand_Right;
		
		health = 100;
		score = 0;
		
		guiScript.curHP = health;
		guiScript.curScore = score;
	}
	
	// Update is called once per frame
	void Update () {
		HandLeft = KScript.Hand_Left;
		HandRight = KScript.Hand_Right;
		
		rigidbody.AddForce(HandLeft.transform.right * playerSpeed);
		rigidbody.AddForce(HandRight.transform.right * -playerSpeed);
		
		if (powerTimer <= 0)
		{
			playerSpeed = 20;
			collisionForce = 2.5;
		}
		else if (powerTimer <= 0 && asteroidsCleared)
		{
			GameObject.Find("AsteroidSpawn").GetComponent<control>().startAsteroids();
			asteroidsCleared = false;
		}
		else
		{
			powerTimer -= Time.deltaTime;
		}
		guiScript.powerTimer = powerTimer;
	}
	
		// explosion method
	void Explode()
	{
		//explode
		System.Random rand = new System.Random();
		int _randomNum = rand.Next(0, _shipExplosions.Length-1);
		
		Instantiate(_shipExplosions[_randomNum],transform.position,transform.rotation);
			
		//destroy
		Destroy(gameObject);
	}
	
	void OnCollisionEnter(Collision hitInfo)
	{
		print(hitInfo.relativeVelocity.magnitude);
		
		// check powerups
		if (hitInfo.gameObject.tag == "Pickup")
		{
			print(hitInfo.gameObject.GetComponent<Pickup>().type);
			powerTimer += 10;
			if (hitInfo.gameObject.GetComponent<Pickup>().type == 1)
			{
				// speed
				playerSpeed += 15;
			}
			else if (hitInfo.gameObject.GetComponent<Pickup>().type == 2)
			{
				// shield
				collisionForce = 18;
			}
			else
			{
				// clear asteroids
				GameObject.Find("AsteroidSpawn").GetComponent<control>().clearAsteroids();
				asteroidsCleared = true;
			}
			//detroy the power up and apply it
			Destroy(hitInfo.gameObject);
			
		}
		else if (hitInfo.relativeVelocity.magnitude > collisionForce)
		{
			//Explode();
			// lose health
			UpdateHealth(hitInfo.relativeVelocity.magnitude * 5);
			
		}
		else if (hitInfo.gameObject.tag == "LandingPad")
		{
			print("landed");
			landingPad.renderer.material.color = otherColor;
			//landingPad.renderer.material.SetColor("_Color", Color.green);
			landingPad.renderer.material.SetColor("_Color", Color.green);
			landingPad.renderer.materials[3].color = otherColor;
			
			// score is a factor of remaining health & time
			float timeScore = ((guiScript.Minutes * 60) + guiScript.Seconds)/3;
			score += 50 + (int)Mathf.Round(health/3) + (int)Mathf.Round(timeScore);
			guiScript.curScore = score;
		}
	}
	
	void UpdateHealth(float hp)
	{
		health -= (int)Mathf.Round(hp);
		
		if (health < 0)
			Explode();
			
		guiScript.curHP = health;
	}
	
}
