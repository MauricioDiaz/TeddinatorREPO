using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour 
{
	public static HealthScript instance;

	public bool shieldToggle = false;
	public bool isEnemy = true;
	public bool startTimer = false;
	public static float timer = 5;
	public float shieldTimer;
	public GameObject particleEffect;

	public CNAbstractController CNcont;

	public int hp = 5;
	public int points;
	public static int pointsTracked;
	
	//public TextMesh scoreText;
	public Text ScoreText;
	public Text LivesText;

	public static float SpeedLimit = 20;
	public Vector2 speed;
	public Vector2 movement;
	//public GameObject blastLocation;
	//public GameObject LaserBlast;
	public AudioClip sound;

	private GameObject ParticleEffect;

	void Awake(){
		instance = this;
		//DontDestroyOnLoad (this.gameObject);
	}


	void Start(){
		//this.gameObject.SetActive (true);
		speed = new Vector2 (SpeedLimit, SpeedLimit);
		GetComponent<AudioSource>().clip = sound;
		shieldToggle = false;
		points = 0;

	}

	void Update()
	{
		points = pointsTracked;
		//checks to see if we are in the correct level

		GetComponent<Rigidbody2D> ().velocity = movement;
	
		//			//Shield Bool
		if (shieldToggle == true)
		{
			timer -= Time.deltaTime;
			GetComponent<CircleCollider2D>().enabled = true;
			GameObject.FindGameObjectWithTag("Shield").GetComponent<Renderer>().enabled = true;
			if(timer <= 0)
			{
				shieldToggle = false;
				timer = shieldTimer;
			}
			
		}
		else if (shieldToggle == false){
			GetComponent<CircleCollider2D>().enabled = false;
			GameObject.FindGameObjectWithTag("Shield").GetComponent<Renderer>().enabled = false;
			
		}
		
		
		//Debug.Log (speed);
		if (hp < 0) {
			//Hides the player
			gameObject.SetActive (false);
			OnDead ();
		}

		if (isMobile == true) {
			float inputX = CNcont.GetAxis ("Horizontal");
			float inputY = CNcont.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
		
			ScoreText.text = ("Score: " + points);
			LivesText.text = ("Health: " + hp);

			StoreScript.Instance.myCoins = points;
		} else {

			//player movement
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);

			ScoreText.text = ("Score: " + points);
			LivesText.text = ("Health: " + hp);

			StoreScript.Instance.myCoins = points;
		}
		
	}



	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		//EnemyHealthScriptCOPY points = collider.gameObject.GetComponent<EnemyHealthScriptCOPY> ();
		ScoreText.text = ("Score: " + points);
		LivesText.text = ("Health: " + hp);


		if(shieldToggle == true)
		{
			if (collider.gameObject.tag == "EnemyBullet")
			{
				Destroy(collider.gameObject);
				hp++;
				//SpecialEffectsHelper.Instance.Explosion(transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
			}

			//If Player crashes with Enemy, enemies dies  if crash with shield
			else if (collider.gameObject.tag == "Enemy")
			{
				Destroy(collider.gameObject);
				//hp--;
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
			}
		}

		else if(shieldToggle == false)
		{
			//If Player crashes with Enemy, enemies dies  if crash with shield
			if (collider.gameObject.tag == "Enemy")
			{
				Destroy(collider.gameObject);
				hp--;
				SpecialEffectsHelper.Instance.Explosion(collider.transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
			}

		}

		//If Player crashes with Enemy, enemies dies without hurting me with the laser collision
		if(collider.gameObject.tag == "Enemy" && collider.gameObject.tag == "Laser")//Laser collision fix
		{
			Destroy(collider.gameObject);
			//hp--;
			//SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
		}

		//Shield
		if (collider.gameObject.tag == "ShieldUpgrade") 
		{
			shieldToggle = true;
			Destroy(collider.gameObject);
		}

		if (collider.gameObject.tag == "Coin") 
		{
			points++;
			pointsTracked++;
			GetComponent<AudioSource>().PlayOneShot(sound);
		}

		if (shot != null)
		{
			//Enemy shot
			if (shot.isEnemyShot != isEnemy || hp == 1)//0 will make it -1
			{

				hp -= shot.damage;
				ScoreText.text = ("Score: " + points);
				LivesText.text = ("Health: " + hp);
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
		transform.parent.gameObject.GetComponent<GameOverScript> ().enabled = true;// Calls the gameover buttons, gets parented to parent because player gets disabled
	}
	
	public bool isMobile//bool to set controls for mobile
	{
		get
		{
			return(Application.platform == RuntimePlatform.Android);
		}
	}

}
