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
	public int bulletAmount = 50;
	public int bulletAmountReset;
	public Text BulletText;


	// Use this for initialization
	void Start () {
		BulletText.enabled = false;
		bulletAmount += StoreScript.Instance._ammo;
		bulletAmountReset = bulletAmount;

	}

	void Update()
	{
		if(Upgrade1 == true)//creates the bullets, starts bullet timer
		{
			BulletText.enabled = true;
			BulletText.text = ("Ammo: " + bulletAmount);
			if(Input.GetButton ("Fire2"))
			{
				Rigidbody2D shoot = (Instantiate(bullet, bullet2Location.transform.position, transform.rotation)) as Rigidbody2D;
				//***************Laser is parented to player so when laser gets hit by enemy bullets, the player gets hurt!!!!
				//SoundEffectsHelper.Instance.MakeMachineGunSound();

				BulletText.text = ("Ammo: " + bulletAmount);
				bulletAmount--;
				if(bulletAmount <= 0)
				{
					Upgrade1 = false;
					BulletText.enabled = false;
					Destroy(Upgrade);
					bulletAmount = bulletAmountReset;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)//trigger to create machinegun,destroy floating obj, and reset the bullets
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
			SoundEffectsHelper.Instance.MakeReloadGunSound();
			GameObject ParticleEffect = (Instantiate(particleEffect, this.gameObject.transform.position,transform.rotation)) as GameObject;
	
		}
	}
}
