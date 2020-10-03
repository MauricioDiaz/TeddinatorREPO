using UnityEngine;
using System.Collections;

public class FireButtonScript : MonoBehaviour {

	public void Fire()
	{
		PlayerControl p = GameObject.Find ("Player").GetComponent<PlayerControl> ();
		p.Shoot ();
		AudioSource fireSound = this.GetComponent<AudioSource> ();
		fireSound.Play ();
	}
}
