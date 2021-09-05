using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	/// <summary>
	/// Launch projectile
	/// </summary>
	public Transform shotPrefab;

	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	private float shootCooldown;

	// Use this for initialization
	void Start () 
	{
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shootCooldown > 0) 
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack) 
		{
			shootCooldown = shootingRate;

			//creates a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			//assign position
			shotTransform.position = transform.position;

			//The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if(shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if(move != null)
			{
				move.direction = this.transform.right;// towards in 2D space is the right of the sprite

			}

		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
