using UnityEngine;
using System.Collections;

public class FireButtonScript : MonoBehaviour {

	public PlayerControl shoot;

	public void Fire()
	{
		shoot.Shoot ();
	}
}
