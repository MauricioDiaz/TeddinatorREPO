
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour 
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	//public Text LivesText;
	public AudioClip healthPackSound;
	
	void OnTriggerEnter2D (Collider2D col)
	{
		PlayerControl health = col.gameObject.GetComponent<PlayerControl> ();
	
		if(col.gameObject.tag == "Player")
		{
			GetComponent<AudioSource>().PlayOneShot(healthPackSound);
			health.hp++;
			//SoundEffectsHelper.Instance.MakeHealthPackSound();
			//LivesText.text = ("Health: " + hp);
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;
			//Destroy(gameObject);//if destroyed it wont play the audioclip
		}
	}
}
