
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScriptCOPY : MonoBehaviour 
{
	/// <summary>
	/// Total hitpoints
	/// </summary>

	public int Sp = 0;
	public int Hp = 1;


	
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

					// Destroy the players shot
					Destroy(shot.gameObject);

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
