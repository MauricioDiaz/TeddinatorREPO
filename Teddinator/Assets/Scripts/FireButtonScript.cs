using UnityEngine;
using System.Collections;

public class FireButtonScript : MonoBehaviour {

	//script is not usefull anymore. Added this function to PlayerControl script attached to Player.
	public void Fire()
	{
		PlayerControl p = GameObject.Find ("Player").GetComponent<PlayerControl>();
		p.Shoot ();
		//AudioSource fireSound = this.GetComponent<AudioSource> ();
		//fireSound.Play ();
		SoundEffectsHelper.Instance.MakePlayerShotSound ();
		//PlayerControl sound = GameObject.Find ("Player").GetComponent<PlayerControl> ();

	}
}
