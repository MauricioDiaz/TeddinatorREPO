using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

	public AudioClip explosionSound;

	void OnTriggerEnter2D(Collider2D collider)
	{
		AudioSource audio = GameObject.Find("Player").GetComponent<AudioSource>();

		// Check if the collider belongs to a PlayerBullet
		if (collider.gameObject.CompareTag("PlayerBullet"))
		{

			SpecialEffectsHelper.Instance.Explosion(transform.position);

			audio.PlayOneShot(explosionSound);
			Destroy (collider.gameObject);

			// Special handling for Supershotprefab
			if (collider.gameObject.name == "Supershotprefab(Clone)")
			{
				
				SpecialEffectsHelper.Instance.Explosion(transform.position);

				audio.PlayOneShot(explosionSound);
				Destroy(gameObject); // Destroy the enemy, NOT the Supershotprefab

			
			}
			// Special handling for Supershotprefab


				// Exit early to prevent further logic from affecting Supershotprefab
				return;
		}

		if (collider.gameObject.CompareTag("Laser"))
		{
			SpecialEffectsHelper.Instance.Explosion(transform.position);

			audio.PlayOneShot(explosionSound);
			Destroy(gameObject); // Destroy the enemy, NOT the Supershotprefab


		}

		if (PlayerControl.instance.shieldToggle != true) //Check for shields to prevent loosing a life when activated
		{
			if (collider.gameObject.tag == "Player") 
			{
				PlayerControl.instance.hp--;
				PlayerControl.instance.LivesText.text = ("" + PlayerControl.instance.hp);

				SpecialEffectsHelper.Instance.Explosion (transform.position);
				SpecialEffectsHelper.Instance.Explosion (transform.position);
				audio.PlayOneShot (explosionSound);
				Destroy (gameObject); // Destroy the barrel
			}
		}
	}

}
