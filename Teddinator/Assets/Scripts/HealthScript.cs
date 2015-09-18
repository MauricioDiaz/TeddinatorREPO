using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour 
{
	public bool toggle = false;
	public bool isEnemy = true;
	public bool startTimer = false;
	public static float timer = 5;
	public float shieldTimer;
	public GameObject particleEffect;

	public CNAbstractController CNcont;

	public int hp = 5;
	public int points;
	public static int myCoins;
	
	//public TextMesh scoreText;
	public Text ScoreText;
	public Text LivesText;

	public Text Coins;
	public Text Cash;
	public int myCash;

	public static float SpeedLimit = 20;
	public Vector2 speed;
	public Vector2 movement;
	//public GameObject blastLocation;
	//public GameObject LaserBlast;
	public AudioClip sound;

	private GameObject ParticleEffect;

	void Awake(){

		//Coins.text = ("Score: " + myCoins);
		Text myS = GetComponent<Text> ();
		//DontDestroyOnLoad (gameObject);
	}


	void Start(){
		//this.gameObject.SetActive (true);
		speed = new Vector2 (SpeedLimit, SpeedLimit);
		GetComponent<AudioSource>().clip = sound;
		toggle = false;

	}

	void Update()
	{
		//checks to see if we are in the correct level
		if (Application.loadedLevelName == "Teddy_Animation_Test_6") {
			GetComponent<Rigidbody2D> ().velocity = movement;
		
			//			//Shield Bool
			if (toggle == true)
			{
				timer -= Time.deltaTime;
				GetComponent<CircleCollider2D>().enabled = true;
				GameObject.FindGameObjectWithTag("Shield").GetComponent<Renderer>().enabled = true;
				if(timer <= 0)
				{
					toggle = false;
					timer = shieldTimer;
				}
				
			}
			else if (toggle == false){
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
			
				//Coins.text = ("Score: " + myCoins);
				//Coins.text = ("COINS " + myCoins);
				//Cash.text = ("CASH ");
				ScoreText.text = ("Score: " + points);
				LivesText.text = ("Health: " + hp);
			} else {

				//player movement
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");
				movement = new Vector2 (speed.x * inputX, speed.y * inputY);

				//Coins.text = ("Score: " + myCoins);
				//Coins.text = ("COINS " + myCoins);
				//Cash.text = ("CASH ");
				ScoreText.text = ("Score: " + points);
				LivesText.text = ("Health: " + hp);
			}
		}
		else if (Application.loadedLevelName == "Store")
		{
			if (isMobile == true) {
				float inputX = CNcont.GetAxis ("Horizontal");
				float inputY = CNcont.GetAxis ("Vertical");
				movement = new Vector2 (speed.x * inputX, speed.y * inputY);
				
				//Coins.text = ("Score: " + myCoins);
				Coins.text = ("COINS " + myCoins);
				//Cash.text = ("CASH ");
				//ScoreText.text = ("Score: " + points);
				//LivesText.text = ("Health: " + hp);
			} else {
				
				//player movement
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");
				movement = new Vector2 (speed.x * inputX, speed.y * inputY);


				//Coins.text = ("Score: " + myCoins);
				Coins.text = ("COINS " + myCoins);
				//Cash.text = ("CASH ");
				//ScoreText.text = ("Score: " + points);
				//LivesText.text = ("Health: " + hp);
			}
		}
	}



	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		//EnemyHealthScriptCOPY points = collider.gameObject.GetComponent<EnemyHealthScriptCOPY> ();
		ScoreText.text = ("Score: " + points);
		LivesText.text = ("Health: " + hp);


		if(toggle == true)
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

		else if(toggle == false)
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
		else if(collider.gameObject.tag == "Enemy" && collider.gameObject.tag == "Laser")//Laser collision fix
		{
			Destroy(collider.gameObject);
			//hp--;
			//SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
		}

		//Shield
		if (collider.gameObject.tag == "ShieldUpgrade") 
		{
			toggle = true;
			Destroy(collider.gameObject);
		}

		else if (collider.gameObject.tag == "Coin") 
		{
			points++;
			myCoins++;
			GetComponent<AudioSource>().PlayOneShot(sound);
		}

		if (shot != null)
		{
			//Enemy shot
			if (shot.isEnemyShot != isEnemy || hp <= 0)
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

	void OnDead(){
		transform.parent.gameObject.AddComponent<GameOverScript>();
		}

	public void ButtonPressed(){
		if (gameObject.name == "Button1") 
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();

			//checks to see if you have enough coins
			if(myCoins >= 100){

				SpeedLimit += 10;
				myCoins -= 100;
				Debug.Log ("Speed-------------------------------: " + SpeedLimit );
			}
			else if(myCoins <= 100)
			{
				Debug.Log("Not Enough Coins Available");
			}
		}
		else if(gameObject.name == "Button2")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 2 Pressed");
		}
		else if(gameObject.name == "Button3")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 3 Pressed");
		}
		else if(gameObject.name == "Button4")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 4 Pressed");
		}
		else if(gameObject.name == "Button5")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 5 Pressed");
		}
		else if(gameObject.name == "Button6")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 6 Pressed");
		}
		else if(gameObject.name == "Button7")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();

			//checks to see if you have enough coins
			if(myCoins >= 50){
				
				timer += 5;
				myCoins -= 50;

			}
			else if(myCoins <= 50)
			{
				Debug.Log("Not Enough Coins Available");
			}
			Debug.Log("Button 7 Pressed");
		}
		else if(gameObject.name == "Button8")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Debug.Log("Button 8 Pressed");
		}
		else if(gameObject.gameObject.name == "Play")
		{
			SoundEffectsHelper.Instance.MakeStoreButtonSound();
			Application.LoadLevel("Teddy_Animation_Test_6");
		}
		else if(gameObject.gameObject.name == "Add")
		{
			myCoins += 20;
		}
	}

	public bool isMobile
	{
		get
		{
			return(Application.platform == RuntimePlatform.Android);
		}
	}

}
