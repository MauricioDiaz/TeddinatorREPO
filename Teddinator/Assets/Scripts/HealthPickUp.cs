
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour 
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	//public Text LivesText;

	
	void OnTriggerEnter2D (Collider2D col)
	{
		HealthScript health = col.gameObject.GetComponent<HealthScript> ();
	
		if(col.gameObject.tag == "Player")
		{

			health.hp++;
			SoundEffectsHelper.Instance.MakeHealthPackSound();
			//LivesText.text = ("Health: " + hp);

			Destroy(gameObject);
		}
	}
}
