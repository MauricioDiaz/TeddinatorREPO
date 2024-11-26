
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour 
{

	public static EnemyHealthScript instance;

	public int Sp = 0;
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
		//HealthScript addPoint = GetComponent<HealthScript>();
	}
	
	
//	void OnTriggerEnter2D(Collider2D collider)
//	{
//		// Is this a shot?
//		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
//		ShotMachineGunScript shot1 = collider.gameObject.GetComponent<ShotMachineGunScript> ();
//		//HealthScript shot2 = collider.gameObject.GetComponent<HealthScript> ();
//		//HealthScript Point = collider.gameObject.GetComponent<HealthScript>();
//
//		//If enemy crashes with player, enemies dies
////		if(collider.gameObject.tag == "Player")
////		{
////
////			Destroy(this.gameObject);
////			SpecialEffectsHelper.Instance.Explosion(transform.position);
////			SoundEffectsHelper.Instance.MakeExplosionSound();
////
////		}
//		
//		if (shot != null)
//		{
//			//Player shot, if player shot hits enemy
//			if (shot.isEnemyShot != isEnemy)
//			{
//				if(collider.gameObject.tag == "PlayerBullet")
//				{
//
//					if (LaserPowerUP.instance != null)
//					{
//						Debug.Log("Calling IncreaseSliderValue...");
//						LaserPowerUP.instance.IncreaseSliderValue(0.1f);
//					}
//					else
//					{
//						Debug.LogError("LaserPowerUP.instance is null!");
//					}
//
//					//LaserPowerUP.instance.oldValue += 0.1f;
//					Hp -= shot.damage;
//					enemiesDestroyed++;//Adds to enemies destroyed count, never resets(highScore)
//					tempEnemiesDestroyed++;//this temp one gets reset everytime player dies
//
//
//					// Destroy the players shot
//					Destroy(shot.gameObject);
////					LaserPowerUP.instance.newValue += 0.1f;
//
//					if (Hp <= 0)
//					{
//
//						SpecialEffectsHelper.Instance.Explosion(transform.position);
//						//SoundEffectsHelper.Instance.MakeExplosionSound();
//						AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
//						audio.PlayOneShot(explosionSound);
//						Debug.Log(enemiesDestroyed);
//
//						//Destroy the enemy 
//						Destroy(gameObject);
//
//					}
//				}
//			}
//		}
//
//		else if (shot1 != null )
//		{
//			//if Playershot
//			if (shot1.isEnemyShot != isEnemy)
//			{
//				Hp -= shot1.damage;
//				enemiesDestroyed++;//Adds to enemies destroyed count, never resets(highScore)
//				tempEnemiesDestroyed++;//this temp one gets reset everytime player dies
//
//
//
//				if (Hp <= 0)
//				{
//					SpecialEffectsHelper.Instance.Explosion(transform.position);
//					//SoundEffectsHelper.Instance.MakeExplosionSound();
//					AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
//					audio.PlayOneShot(explosionSound);
//					Debug.Log(enemiesDestroyed);
//
//					//Destroy the enemy 
//					Destroy(gameObject);
////					LaserPowerUP.instance.newValue += 0.1f;
//				}			
//			}
//		}
//	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		// Check if the collider belongs to a PlayerBullet
		if (collider.gameObject.CompareTag("PlayerBullet"))
		{
			ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
			if (shot != null && shot.isEnemyShot != isEnemy) // Ensure it's the player's shot
			{
				LaserPowerUP.instance.IncreaseSliderValue(0.1f);

				Hp -= shot.damage;
				enemiesDestroyed++; // Adds to enemies destroyed count
				tempEnemiesDestroyed++; // This temp one resets when the player dies

				Destroy(shot.gameObject); // Destroy the player's shot

				if (Hp <= 0)
				{
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
					audio.PlayOneShot(explosionSound);

					Debug.Log(enemiesDestroyed);

					// Destroy the enemy
					Destroy(gameObject);
				}
			}
		}
	}

}
