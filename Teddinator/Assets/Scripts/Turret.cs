using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool shoot = Input.GetButtonDown("Fire1");
		//shoot |= Input.GetButtonDown ("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea

		
		if (shoot) 
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();//player shot sound
			}
		}
	
	}
}
