using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class AimBotEnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private AimBotWeaponScript[] weapons;
	
	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<AimBotWeaponScript>();
		
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		
		// Disable everything

		// -- collider
		GetComponent<Collider2D>().enabled = false;
		// -- Moving
		moveScript.enabled = false;
		// -- Shooting
		foreach (AimBotWeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			// Auto-fire
			foreach (AimBotWeaponScript w in weapons)
			{
				if (w != null && w.enabled && w.CanAttack)
				{
					w.Attack(true);
					SoundEffectsHelper.Instance.MakeEnemyShotSound ();
				}
			}
			
			// 4 - Out of the camera ? Destroy the game object.
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		GetComponent<SpriteRenderer>().enabled = true;
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		GetComponent<Collider2D>().enabled = true;
		// -- Moving
		// -- Collider
		GetComponent<MoveScript>().enabled = true;
		//moveScript.enabled = true;
		// -- Shooting
		foreach (AimBotWeaponScript w in weapons)
		{
			w.enabled = true;
		}
	}
}

