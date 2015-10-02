using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
	{
		//bool shoot = Input.GetButtonDown("Fire1");
		
		if (Input.GetButtonDown("Fire1")) 
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
