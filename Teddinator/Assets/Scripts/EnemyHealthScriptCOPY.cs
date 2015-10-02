
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScriptCOPY : MonoBehaviour 
{
	public int Sp = 0;
	public int Hp = 1;

	public bool isEnemy = true;
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		ShotMachineGunScript shot1 = collider.gameObject.GetComponent<ShotMachineGunScript> ();

		
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
