
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour 
{

	public static EnemyHealthScript instance;

	//public int Sp = 0;
	public int Hp = 1;

	public static int enemiesDestroyed;
	public static int tempEnemiesDestroyed;
	//enemiesDestroyed++;//Adds to enemies destroyed count
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;

	public AudioClip explosionSound;

	//public TextMesh scoreText;
	//public Text ScoreText;
	//public Canvas canvas;



	void Start()
	{
		instance = this;
	}

	void Update()
	{
		//loads and updates the enemies kill high score 
		enemiesDestroyed = PlayerPrefs.GetInt ("Most Enemies Destroyed");

		if(tempEnemiesDestroyed > enemiesDestroyed)
		{
			enemiesDestroyed = tempEnemiesDestroyed;
			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDestroyed);
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		// Check if the collider belongs to a PlayerBullet
		if (collider.gameObject.CompareTag("PlayerBullet"))
		{
			ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
			ShotMachineGunScript machineshot = collider.gameObject.GetComponent<ShotMachineGunScript>();



			// Special handling for Supershotprefab
			if (collider.gameObject.name == "Supershotprefab(Clone)")
			{
				LaserPowerUP.instance.IncreaseSliderValue(0.05f);
				// Ensure it's the player's shot and does not damage enemies
				if (shot != null && shot.isEnemyShot != isEnemy)
				{
					Hp -= shot.damage; // Inflict damage
					//enemiesDestroyed++; // Update destroyed count
					tempEnemiesDestroyed++;

					// Handle enemy destruction
					if (Hp <= 0)
					{
						SpecialEffectsHelper.Instance.Explosion(transform.position);
						AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
						audio.PlayOneShot(explosionSound);

						Destroy(gameObject); // Destroy the enemy, NOT the Supershotprefab
					}
				}

				// Exit early to prevent further logic from affecting Supershotprefab
				return;
			}

			// For all other PlayerBullets
			if (shot != null && shot.isEnemyShot != isEnemy)
			{
				LaserPowerUP.instance.IncreaseSliderValue(0.05f);

				Hp -= shot.damage; // Inflict damage
				//enemiesDestroyed++;
				tempEnemiesDestroyed++;

				Destroy(shot.gameObject); // Destroy regular player's shots

				if (Hp <= 0)
				{
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
					audio.PlayOneShot(explosionSound);

					Destroy(gameObject); // Destroy the enemy
				}
			}

			if (machineshot != null && machineshot.isEnemyShot != isEnemy)
			{
				LaserPowerUP.instance.IncreaseSliderValue(0.05f);

				Hp -= machineshot.damage; // Inflict damage
				//enemiesDestroyed++;
				tempEnemiesDestroyed++;

				if (Hp <= 0)
				{
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
					audio.PlayOneShot(explosionSound);

					Destroy(gameObject); // Destroy the enemy
				}
			}
		}
	}



}
