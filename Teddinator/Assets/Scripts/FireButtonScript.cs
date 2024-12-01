using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FireButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private PlayerControl playerControl;

	void Start()
	{
		playerControl = GameObject.Find ("Player").GetComponent<PlayerControl> ();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		playerControl.StartCharging (); // Sart charging bullet
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		playerControl.StopChargingAndShoot (); //Fire bullet based on charge
	}

	// Wrapper method for OnPointerDown (can be called via EventTrigger)
	public void FireButtonPressed()
	{
		OnPointerDown(null);
	}

	// Wrapper method for OnPointerUp (can be called via EventTrigger)
	public void FireButtonReleased()
	{
		OnPointerUp(null);
	}




	//script is not usefull anymore. Added this function to PlayerControl script attached to Player.
//	public void Fire()
//	{
//		PlayerControl p = GameObject.Find ("Player").GetComponent<PlayerControl>();
//		p.Shoot ();
//		//AudioSource fireSound = this.GetComponent<AudioSource> ();
//		//fireSound.Play ();
//		SoundEffectsHelper.Instance.MakePlayerShotSound ();
//		//PlayerControl sound = GameObject.Find ("Player").GetComponent<PlayerControl> ();
//
//	}
}
