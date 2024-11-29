using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

	public AudioClip explosionSound;

	void OnTriggerEnter2D(Collider2D collider)
	{
//		if (collider.gameObject.CompareTag ("PlayerBullet")) 
//		{
//			
//			SpecialEffectsHelper.Instance.Explosion(transform.position);
//			AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
//			audio.PlayOneShot(explosionSound);
//			Destroy (collider.gameObject);
//
//		}
		// Check if the collider belongs to a PlayerBullet
		if (collider.gameObject.CompareTag("PlayerBullet"))
		{
//			ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
//			ShotMachineGunScript machineshot = collider.gameObject.GetComponent<ShotMachineGunScript>();

			SpecialEffectsHelper.Instance.Explosion(transform.position);
			AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();
			audio.PlayOneShot(explosionSound);
			Destroy (collider.gameObject);

			// Special handling for Supershotprefab
			if (collider.gameObject.name == "Supershotprefab(Clone)")
			{
				
				SpecialEffectsHelper.Instance.Explosion(transform.position);

				audio.PlayOneShot(explosionSound);
				Destroy(gameObject); // Destroy the enemy, NOT the Supershotprefab
			
			}

				// Exit early to prevent further logic from affecting Supershotprefab
				return;
		}
	}

}
