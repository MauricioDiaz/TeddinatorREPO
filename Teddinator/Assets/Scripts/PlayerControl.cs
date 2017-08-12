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
	public static int pointsTracked;
	public int gameOverPoint;
	public Text ScoreText;
	public Text LivesText;
	public Text currentScore;
	
	
	public static float speedLimit = 20;
	public Vector2 speed;
	public Vector2 movement;
	public GameObject bulletLocation;
	public GameObject bullet;
	//private float shootCooldown;
	//public float shootingRate;

	public bool isShot;

	public AudioClip sound;
	
	private GameObject ParticleEffect;
	
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
		GetComponent<AudioSource>().clip = sound;
		shieldTimerReset = shieldTimer;
		gameOverPoint = 0;
		pointsTracked = 0;
		isShot = true;
	}
	
	void Update()
	{
		//movement
		GetComponent<Rigidbody2D> ().velocity = movement;
		
		Debug.Log ("POINTS: " + points);
		Debug.Log ("POINTSTRACKED: " + pointsTracked);

		//Shield Bool
		if (shieldToggle == true)
		{
			//shield gets turned on
			shieldGO.GetComponent<Renderer>().enabled = true;
			shieldTimer -= Time.deltaTime;
			GetComponent<CircleCollider2D>().enabled = true;
			
			Debug.Log("Renderer color: " + shieldGO.GetComponent<Renderer>().material.color);
			
			
			if(shieldTimer <= 3.0f)
			{
				//switches shield color red to white ever 1 second
				float lerptime = Mathf.PingPong(Time.time, 1) / 1;
				shieldGO.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.Lerp(whiteshield,redshield, lerptime);

				Debug.Log("Renderer name: " + shieldGO.GetComponent<Renderer>().material.name);
				Debug.Log("Renderer color: " + shieldGO.GetComponent<Renderer>().material.color);
				
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
		
		if (hp < 0) 
		{
			//Hides the player
			gameObject.SetActive (false);
			OnDead ();
		}
		
		if (isMobile == true)///On cellphone ***************
		{
//			if (shootCooldown > 0) 
//			{
//				shootCooldown -= Time.deltaTime;
//			}



//			if (CanAttack)
//			{
//				//shootCooldown = shootingRate;
//				if(Input.GetButtonDown ("Fire1"))//GetButton is the original 8/11/2017
//				{
//					Rigidbody2D shoot = (Instantiate(bullet, bulletLocation.transform.position, transform.rotation)) as Rigidbody2D;
//
//				}
////				else if (Input.GetButtonUp ("Fire1")) 
////				{
////					Debug.Log("UP");
////					shootingRate = 0;
////
////				}
//
//			}
			
			//On cellphone
			float inputX = CNcont.GetAxis ("Horizontal");
			float inputY = CNcont.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
			
			StoreScript.Instance.myCoins = points;//tracks coins throughout game
			
		} 
		else//On the computer ***********
		{
			
//			if (shootCooldown > 0) 
//			{
//				shootCooldown -= Time.deltaTime;
//			}




//			if (CanAttack)
//			{
//				//shootCooldown = shootingRate;
//				if(Input.GetButton ("Fire1"))
//				{
//					Rigidbody2D shoot = (Instantiate(bullet, bulletLocation.transform.position, transform.rotation)) as Rigidbody2D;
//
//				}
//			}
			
			//player movement
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
			
			
			//points += PointPopUps.instance._point;
			StoreScript.Instance.myCoins = points;//tracks coins throughout game
			//StoreScript.Instance.myCoins = pointsTracked;//tracks coins throughout game
			
		}
		
	}

	public void Shoot()
	{
		Rigidbody2D shoot = (Instantiate(bullet, bulletLocation.transform.position, transform.rotation)) as Rigidbody2D;
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
		}
		
		//When Shield is active
		if(shieldToggle == true)
		{
			if (collider.gameObject.tag == "EnemyBullet")
			{
				Destroy(collider.gameObject);
				SoundEffectsHelper.Instance.MakeExplosionSound();
			}
			
			//If Player crashes with Enemy, enemies dies  if crash with shield
			if (collider.gameObject.tag == "Enemy")
			{
				Destroy(collider.gameObject);
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
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
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
			}
			
		}
		
		//		//Enemys *Try placing this code in shield
		//		if (collider.gameObject.tag == "Coin") 
		//		{
		//			points += 10;
		//			pointsTracked++;
		//			GetComponent<AudioSource>().PlayOneShot(sound);
		//		}
		
		//Coins
		if (collider.gameObject.tag == "Coin") 
		{
			
			points++;
			pointsTracked++;
			GetComponent<AudioSource>().PlayOneShot(sound);
			
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
				SoundEffectsHelper.Instance.MakeExplosionSound();
				
				if (hp <= 0 && collider.gameObject.tag != "PlayerBullet")
				{
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound();
					
					//Hides the player
					gameObject.SetActive(false);
					OnDead();
				}
				
			}
		}
	}
	
	void OnDead()
	{
		points = pointsTracked;
		//pointsTracked += gameOverPoint;
		
		transform.parent.gameObject.GetComponent<GameOverScript> ().enabled = true;// Calls the gameover buttons, gets parented to parent because player gets disabled
		
		
	}
	
	public bool isMobile//bool to set controls for mobile
	{
		get
		{
			return(Application.platform == RuntimePlatform.Android);
		}
	}
	
//	public bool CanAttack
//	{
//		get
//		{
//			return shootCooldown <= 0f;
//		}
//	}
	
}
