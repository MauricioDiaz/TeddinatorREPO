
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour 
{
	/// <summary>
	/// Total hitpoints
	/// </summary>

	public int Sp = 0;
	public int Hp = 1;

	public static int enemiesDestroyed;
	public static int tempEnemiesDestroyed;
	//enemiesDestroyed++;//Adds to enemies destroyed count
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	//public TextMesh scoreText;
	//public Text ScoreText;
	//public Canvas canvas;

	void Start()
	{
		//HealthScript addPoint = GetComponent<HealthScript>();
	}
	
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		ShotMachineGunScript shot1 = collider.gameObject.GetComponent<ShotMachineGunScript> ();
		//HealthScript shot2 = collider.gameObject.GetComponent<HealthScript> ();
		//HealthScript Point = collider.gameObject.GetComponent<HealthScript>();

		//If enemy crashes with player, enemies dies
//		if(collider.gameObject.tag == "Player")
//		{
//
//			Destroy(this.gameObject);
//			SpecialEffectsHelper.Instance.Explosion(transform.position);
//			SoundEffectsHelper.Instance.MakeExplosionSound();
//
//		}
		
		if (shot != null)
		{
			//Player shot, if player shot hits enemy
			if (shot.isEnemyShot != isEnemy)
			{
				if(collider.gameObject.tag == "PlayerBullet")
				{
					Hp -= shot.damage;
					enemiesDestroyed++;//Adds to enemies destroyed count, never resets(highScore)
					tempEnemiesDestroyed++;//this temp one gets reset everytime player dies

					// Destroy the players shot
					Destroy(shot.gameObject);

					if (Hp <= 0)
					{
						//Destroy the enemy 
						Destroy(gameObject);
						SpecialEffectsHelper.Instance.Explosion(transform.position);
						SoundEffectsHelper.Instance.MakeExplosionSound();


					}
				}
			}
		}

		else if (shot1 != null )
		{
			//if Playershot
			if (shot1.isEnemyShot != isEnemy)
			{
				Hp -= shot1.damage;

				if (Hp <= 0)
				{
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound();
					//Destroy the enemy 
					Destroy(gameObject);	
				}			
			}
		}
	}
}
