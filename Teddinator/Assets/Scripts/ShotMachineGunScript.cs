using UnityEngine;
using System.Collections;

public class ShotMachineGunScript : MonoBehaviour 
{
	public int damage = 1;
	public int points = 0;
	//private HealthScript healthHp;
	public bool isEnemyShot = false;

	public AudioClip explosionSound;

	void OnTriggerEnter2D(Collider2D collider)
	{
		//Debug.Log ("Collision with : " + collider);
		// Check if the collider belongs to a PlayerBullet
		if (collider.gameObject.tag == "Barricade" || collider.gameObject.tag == "Enemy") 
		{

			SpecialEffectsHelper.Instance.Explosion (transform.position);
			AudioSource audio = GameObject.Find ("Player").GetComponent<AudioSource> ();
			audio.PlayOneShot (explosionSound);


			Destroy (this.gameObject);

		}
	}
}