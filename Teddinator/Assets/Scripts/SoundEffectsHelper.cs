using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelper : MonoBehaviour
{
	
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectsHelper Instance;


	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;
	public AudioClip onHoverButtonSound;
	public AudioClip onClickButtonSound;
	public AudioClip MenuSongSound;
	public AudioClip MachineGunSound;
	public AudioClip ReloadGunSound;
	public AudioClip HealthPackSound;
	public AudioClip StoreButtonSound;
	public AudioClip LaserBlastSound;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}
	
	public void MakeExplosionSound()
	{
		MakeSound(explosionSound);
	}
	
	public void MakePlayerShotSound()
	{
		MakeSound(playerShotSound);
	}
	
	public void MakeEnemyShotSound()
	{
		MakeSound(enemyShotSound);
	}
	public void MakeOnHoverButtonSound()
	{
		MakeSound(onHoverButtonSound);
	}
	public void MakeOnClickButtonSound()
	{
		MakeSound(onClickButtonSound);
	}
	public void MakeMenuSongSound()
	{
		MakeSound(MenuSongSound);
	}
	public void MakeMachineGunSound()
	{
		MakeSound1 (MachineGunSound);
		//audio.PlayOneShot (MachineGunSound);
	}
	public void MakeReloadGunSound()
	{
		MakeSound (ReloadGunSound);

	}
	public void MakeHealthPackSound()
	{
		MakeSound (HealthPackSound);
		
	}
	public void MakeStoreButtonSound()
	{
		MakeSound (StoreButtonSound);
		
	}
	public void MakeLaserBlastSound()
	{
		MakeSound (LaserBlastSound);
		
	}
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);


	}

	private void MakeSound1(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
		GetComponent<AudioSource>().pitch = .01f;//should change the speed of the sound;
		
		
	}

}