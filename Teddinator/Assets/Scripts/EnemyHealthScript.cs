using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour 
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int EnemyHp = 1;
	private int NewEnemyHp = 0;

	public bool isEnemy = true;
	
	//public TextMesh livesText;


	void Start()
	{

		//LivesText = GetComponent<Text> ();
	}

	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();


		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				EnemyHp -= shot.damage;	

				NewEnemyHp++;
				}
			}
		}
	}
