using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponUpgradeScript : MonoBehaviour {

	public GameObject Weapon;
	public GameObject bullet;
	public GameObject turretLocation;
	public GameObject bullet2Location;
	public GameObject particleEffect;
	public float bulletSpeed;
	public bool Upgrade1 = false;
	private GameObject Upgrade;
	//private GameObject ParticleEffect;
	private int bulletAmount = 50;
	public Text BulletText;


	// Use this for initialization
	void Start () {
		//BulletText.text = false;
		BulletText.enabled = false;

	}

	void Update()
	{
		if(Upgrade1 == true)//creates the bullets, starts bullet timer
		{
			BulletText.enabled = true;
			if(Input.GetButton ("Fire2")&& !GetComponent<AudioSource>().isPlaying)
			{
				//GameObject newParent = GameObject.Find ("UpgradeWeaponLocation");
				Rigidbody2D shoot = (Instantiate(bullet, bullet2Location.transform.position, transform.rotation)) as Rigidbody2D;
				//bullet.transform.parent = newParent.transform;
				//***************Laser is parented to player so when laser gets hit by enemy bullets, the player gets hurt!!!!

				//shoot.transform.parent = turretLocation.transform;
				//SoundEffectsHelper.Instance.MakeMachineGunSound();

				//BulletText.text = true;
				BulletText.text = ("Bullets: " + bulletAmount);

				bulletAmount--;
				//Debug.Log(timer);
				if(bulletAmount <= 0)
				{
					Upgrade1 = false;
					BulletText.enabled = false;
					Destroy(Upgrade);

				}


			}
		}

	}



	void OnTriggerEnter2D(Collider2D col)//trigger to create machinegun,destroy floating obj, and reset the timer
	{
		if(col.gameObject.tag == "Weapon")
		{
			Destroy(col.gameObject);

			GameObject newParent = GameObject.Find ("UpgradeWeaponLocation");
			Upgrade = (Instantiate(Weapon, turretLocation.transform.position,transform.rotation)) as GameObject;
			Upgrade.transform.SetParent(newParent.transform, true);
			Upgrade.transform.localScale = new Vector3(7, 7, 7);
			//newParent.transform = Upgrade.transform.parent;
			Upgrade1 = true;
			bulletAmount = 2;
			SoundEffectsHelper.Instance.MakeReloadGunSound();
			GameObject ParticleEffect = (Instantiate(particleEffect, this.gameObject.transform.position,transform.rotation)) as GameObject;
	
		}

	}




}
