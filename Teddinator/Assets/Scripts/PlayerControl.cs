using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour 
{
	public static PlayerControl instance;
	
	public bool shieldToggle = false;
	bool isEnemy = false;
	
	public float shieldTimer;
	public float shieldTimerReset;
	public GameObject particleEffect;
	public GameObject shieldGO;
	public Material whiteshield;
	public Material redshield;
	
	public CNAbstractController CNcont;
	
	public int hp;
	public int points;
	//public static int enemiesDestroyed;
	public static int pointsTracked;
	public int gameOverPoint;
	public Text ScoreText;
	public Text LivesText;
	public Text currentScore;
	public Button fireButton;
	
	
	public static float speedLimit = 20;
	public Vector2 speed;
	public Vector2 movement;
	public GameObject bulletLocation;
	public GameObject bullet;
	//private float shootCooldown;
	//public float shootingRate;

	public bool isShot;
	private GameObject ParticleEffect;

	public AudioClip coinSound;
	public AudioClip playerShotSound;
	public AudioClip playerSuperShotSound;
	public AudioClip chargeShotSound;
	public AudioClip powerupSound;
	public AudioClip explosionSound;


	public int tempSkinNub;
	public Sprite skin;


	public float maxPowerUpCharge = 3.0f; // Maximum charge time
	private float powerUpCharge = 0f;    // Current charge
	public GameObject poweredBullet;    // Reference to powered-up bullet prefab
	private bool isCharging = false;
	private bool shotFired = false;
	private bool hasPlayedChargeSound = false; // Ensure sound plays only once during charging



	void Awake(){
		instance = this;
	}
	
	
	void Start(){
		shieldToggle = false;
		//points = 0;
		hp += StoreScript.Instance._hp;
		speedLimit += StoreScript.Instance._speed;
		shieldTimer += StoreScript.Instance._shieldTimer;
		speed = new Vector2 (speedLimit, speedLimit);
		//GetComponent<AudioSource>().clip = sound;//not sure what this audiosource clip is for
		shieldTimerReset = shieldTimer;
		gameOverPoint = 0;
		pointsTracked = 0;
		isShot = true;

		//Tedy skins
		GameObject skinObj = GameObject.Find ("_StoreScripts");
		GameObject skinRef = GameObject.Find ("_StoreScripts");	
		tempSkinNub = skinObj.GetComponent<StoreScript>().skinNub;
		skin = skinRef.GetComponent<StoreScript> ().skinChoice;
		Debug.Log (tempSkinNub);
		
		if (tempSkinNub == 1)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);

			if (PlayerPrefs.GetInt("Skin") == 1 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}
		else if (tempSkinNub == 2)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);

			if (PlayerPrefs.GetInt("Skin") == 2 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}
		else if (tempSkinNub == 3)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);

			if (PlayerPrefs.GetInt("Skin") == 3 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}
		else if (tempSkinNub == 4)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);
			
			if (PlayerPrefs.GetInt("Skin") == 4 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}
		else if (tempSkinNub == 5)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);
			
			if (PlayerPrefs.GetInt("Skin") == 5 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}
		else if (tempSkinNub == 6)
		{
			
			PlayerPrefs.GetInt("Skin", tempSkinNub);

			if (PlayerPrefs.GetInt("Skin") == 6 )
			{
				Debug.Log("Skin Changed!");
				//GetComponent<skin>().skinOne = this.gameObject.GetComponent<Sprite>();
				//gameObject.GetComponent<SpriteRenderer>().sprite = StoreScript.instance.skinOne;
				GetComponent<SpriteRenderer>().sprite = skin;
			}
			
		}

	}
	
	void Update()
	{

		//movement
		GetComponent<Rigidbody2D> ().velocity = movement;
		
	

		//Shield Bool
		if (shieldToggle == true)
		{
			//shield gets turned on
			shieldGO.GetComponent<Renderer>().enabled = true;
			shieldTimer -= Time.deltaTime;
			GetComponent<CircleCollider2D>().enabled = true;
			
//			Debug.Log("Renderer color: " + shieldGO.GetComponent<Renderer>().material.color);
			
			
			if(shieldTimer <= 3.0f)
			{
				//switches shield color red to white ever 1 second
				float lerptime = Mathf.PingPong(Time.time, 1) / 1;
				shieldGO.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.Lerp(whiteshield,redshield, lerptime);

//				Debug.Log("Renderer name: " + shieldGO.GetComponent<Renderer>().material.name);
//				Debug.Log("Renderer color: " + shieldGO.GetComponent<Renderer>().material.color);
				
			}
			
			if(shieldTimer <= 0)
			{
				shieldToggle = false;
				shieldTimer = shieldTimerReset;
				shieldGO.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = new Material(whiteshield);//sets shield back to white
			}
			
		}
		else if (shieldToggle == false)
		{
			GetComponent<CircleCollider2D>().enabled = false;
			shieldGO.GetComponent<Renderer>().enabled = false;
			
		}
		
		if (hp <= 0) 
		{
			//Hides the player
			gameObject.SetActive (false);
			OnDead ();
		}
		
		if (isMobile == true)///On cellphone ***************
		{

			
			//On cellphone
			float inputX = CNcont.GetAxis ("Horizontal");
			float inputY = CNcont.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
			
			StoreScript.Instance.myCoins = points;//tracks coins throughout game
			
		} 
		else//On the computer ***********
		{
			
			//player movement
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
			
			
			//points += PointPopUps.instance._point;
			StoreScript.Instance.myCoins = points;//tracks coins throughout game
	
		}

		//TEST Mouse down click---------
//		if (Input.GetMouseButtonDown (0)) 
//		{
//			StartCharging ();
//		}
//
//		if (Input.GetMouseButtonUp (0)) 
//		{
//			StopChargingAndShoot ();
//		}

		if (isCharging) 
		{
			//Debug.Log ("hasPlayedChargeSound = " + hasPlayedChargeSound);
			// Play charge sound once when charging starts
			if (!hasPlayedChargeSound)
			{
				GetComponent<AudioSource>().PlayOneShot(chargeShotSound);//plays audio when button pressed
				hasPlayedChargeSound = true; // Prevent multiple plays
			}

			powerUpCharge += Time.deltaTime;
//			Debug.Log ("Charging.... Current charge: " + powerUpCharge.ToString("0"));

			if (powerUpCharge >= maxPowerUpCharge) {
				powerUpCharge = maxPowerUpCharge;
//				Debug.Log ("MaxPowerUpCharge= " + maxPowerUpCharge.ToString ("0"));
//				Debug.Log ("powerUpCharge= " + powerUpCharge.ToString ("0"));
				//FirePoweredBullet ();//if you turn this back on it will shott an infinite amount until you let go off the button
				//Debug.Log ("Charge reached Max level!");

			} 
//			else 
//			{
//				hasPlayedChargeSound = false;
//			}
//			if(charge >= maxChargeTime)
//			{
//				charge = maxChargeTime;
//				FirePoweredBullet ();
//				Debug.Log ("Charge reached Max level!");
//
//			}

		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		
		//EnemyHealthScriptCOPY points = collider.gameObject.GetComponent<EnemyHealthScriptCOPY> ();
		ScoreText.text = ("" + points);
		LivesText.text = ("" + hp);
		
		//Shield
		if (collider.gameObject.tag == "ShieldUpgrade") 
		{
			shieldToggle = true;
			Destroy(collider.gameObject);
			GetComponent<AudioSource>().PlayOneShot(powerupSound);
		}
		
		//When Shield is active
		if(shieldToggle == true)
		{
			if (collider.gameObject.tag == "EnemyBullet")
			{
				Destroy(collider.gameObject);
				//SoundEffectsHelper.Instance.MakeExplosionSound();
				GetComponent<AudioSource>().PlayOneShot(explosionSound);
			}
			
			//If Player crashes with Enemy, enemies dies  if crash with shield
			if (collider.gameObject.tag == "Enemy")
			{
				Destroy(collider.gameObject);
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				//SoundEffectsHelper.Instance.MakeExplosionSound();
				GetComponent<AudioSource>().PlayOneShot(explosionSound);

			}
		}
		
		//if Shiled is not acitve
		if(shieldToggle == false)
		{
			//If Player crashes with Enemy, enemies dies  if crash with shield
			if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "EnemyBullet")
			{
				Destroy(collider.gameObject);
				hp--;
				LivesText.text = ("" + hp);
				//LivesText
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				//SoundEffectsHelper.Instance.MakeExplosionSound();
				GetComponent<AudioSource>().PlayOneShot(explosionSound);

			}
			
		}
	
		//Coins
		if (collider.gameObject.tag == "Coin") 
		{
			
			points++;
			pointsTracked++;
			GetComponent<AudioSource>().PlayOneShot(coinSound);
			
		}
		
		if (shot != null)
		{
			//if enemy shot doesnt equal player
			if (shot.isEnemyShot != isEnemy  || hp == 0)
			{
				ScoreText.text = ("" + points);
				LivesText.text = ("" + hp);
				// Destroy the shot from the enemy
				Destroy(shot.gameObject);
				
				//Creates the explosion
				GameObject newParent1 = GameObject.FindGameObjectWithTag("Player");
				ParticleEffect = (Instantiate(particleEffect, collider.transform.position,transform.rotation)) as GameObject;
				ParticleEffect.transform.SetParent(newParent1.transform, true);
				//SoundEffectsHelper.Instance.MakeExplosionSound();
				GetComponent<AudioSource>().PlayOneShot(explosionSound);
							
			}
		}

	}
	
	void OnDead()
	{
		points = pointsTracked;
		//pointsTracked += gameOverPoint;
		//fireButton.enabled = false;
		fireButton.gameObject.SetActive (false);
		//laserButton.gameObject.SetActive (false);
		LaserPowerUP.instance.laserButton.gameObject.SetActive(false);
		Destroy(GameObject.Find("LaserPrefab(Clone)"), 3f);
		transform.parent.gameObject.GetComponent<GameOverScript> ().enabled = true;// Calls the gameover buttons, gets parented to parent because player gets disabled
	
	}

	public void StartCharging()
	{
		//hasPlayedChargeSound = false;
		//hasPlayedChargeSound = true; // Prevent multiple plays


		isCharging = true;
		powerUpCharge = 0f; // Reset charge when starting
		shotFired = false;
		//Debug.Log("Charging Started"); // Debug log to confirm charging
		//GetComponent<AudioSource>().PlayOneShot(chargeShotSound);
	
	}

	public void StopChargingAndShoot()
	{
		if (isCharging && !shotFired)
		{
			hasPlayedChargeSound = false;

			isCharging = false;  // Stop charging
			shotFired = true;    // Prevent shooting again until charged

			//hasPlayedChargeSound = false;
			//Debug.Log("Charging Stopped, power up charge: " + powerUpCharge.ToString("0")); // Debug log to check charge

			//Destroy (chargeShotSound);
			//GetComponent<AudioSource> ().PlayOneShot (chargeShotSound);
//			GetComponent<AudioSource> ().mute = true;
//			Destroy (chargeShotSound);
//

			// Determine bullet type based on charge
			if (powerUpCharge >= maxPowerUpCharge)
			{
				// Fire powered-up bullet
				FirePoweredBullet();
				//Debug.Log("Fired Powered Bullet!");
				//GetComponent<AudioSource> ().PlayOneShot (chargeShotSound);
				//GetComponent<AudioSource> ().Stop();
				//Destroy (chargeShotSound);
				hasPlayedChargeSound = false;
			}
			else
			{
				// Fire normal bullet (implement your firing logic here)
				FireNormalBullet();
				GetComponent<AudioSource> ().Stop();
				//Debug.Log("Fired Normal Bullet!");

			}

			// Reset the charge after firing
			powerUpCharge = 0f;
		}
	}

	public void FireNormalBullet()
	{
		// Instantiate normal bullet
		Instantiate(bullet, bulletLocation.transform.position, bulletLocation.transform.rotation);
		// Add sound effect, etc.
		GetComponent<AudioSource>().PlayOneShot(playerShotSound);

	}

	private void FirePoweredBullet()
	{
		// Instantiate powered-up bullet
		Instantiate(poweredBullet, bulletLocation.transform.position, bulletLocation.transform.rotation);
		// Add sound effect, etc.
		GetComponent<AudioSource>().PlayOneShot(playerSuperShotSound);
	}


	public void Shoot()
	{
		//Rigidbody2D shoot = (Instantiate(bullet, bulletLocation.transform.position, transform.rotation)) as Rigidbody2D;
		Rigidbody2D shoot = (Instantiate(bullet, bulletLocation.transform.position, transform.rotation)) as Rigidbody2D;
		shoot.velocity = new Vector2(speed.x, 0); // Regular bullet speed
		GetComponent<AudioSource>().PlayOneShot(playerShotSound);
	}
//
//	public void Fire()
//	{
//		Shoot ();
//		GetComponent<AudioSource>().PlayOneShot(playerShotSound);
//		//SoundEffectsHelper.Instance.MakePlayerShotSound();
//	}
	
	public bool isMobile//bool to set controls for mobile
	{
		get
		{
			return(Application.platform == RuntimePlatform.Android);
		}
	}
}
