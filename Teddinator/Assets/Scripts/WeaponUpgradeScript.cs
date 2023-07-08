using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponUpgradeScript : MonoBehaviour {

	//public static WeaponUpgradeScript instance;

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

	public AudioClip machineGunSound;
	public AudioClip powerupSound;

	// Use this for initialization
	void Start () {
		BulletText.enabled = false;
		bulletAmount += StoreScript.Instance._ammo;
		bulletAmountReset = bulletAmount;

	}

	void Update()
	{
		//Debug.Log (Upgrade1);
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

					GetComponent<AudioSource>().Stop();
					Upgrade1 = false;
					BulletText.enabled = false;
					Destroy(Upgrade);//weapon sprite
					bulletAmount = bulletAmountReset;

				}


			}
			if(Input.GetButtonDown ("Fire2"))
			{
				//SoundEffectsHelper.Instance.MakeMachineGunSound();
				GetComponent<AudioSource>().PlayOneShot(machineGunSound);
			}
			if(Input.GetButtonUp("Fire2"))
			{
				GetComponent<AudioSource>().Stop();
				//Destroy(GameObject.Find("One shot audio"));
				if(bulletAmount <= 0)
				{
					GetComponent<AudioSource>().Stop();
				}
			}
		}
	}

//	public void HoldFireDown()
//	{
//		Debug.Log ("HoldFireDown");
//		//Trying to get the machine gun sound to work
//		if(Upgrade1 == true)//creates the bullets, starts bullet timer
//		{
//			Debug.Log("Its true!");
//			SoundEffectsHelper.Instance.MakeMachineGunSound();
//			audioReady = false;
//		}
//	}
//	
//	public void HoldFireUp()
//	{
//		Debug.Log ("HoldFireUp");
//		//Destroy(GameObject.Find("One shot audio"));
//		if(bulletAmount <= 0)
//		{
//			Destroy(GameObject.Find("One shot audio"));
//		}
//	}

	void OnTriggerEnter2D(Collider2D col)//trigger to create machinegun,destroy floating obj, and reset the bullets
	{

		if (col.gameObject.tag == "Weapon") 
		{
			Debug.Log ("TriggerEnter");
			GetComponent<AudioSource>().PlayOneShot(powerupSound);
			Upgrade1 = true;
			Destroy (col.gameObject);//blue floating ballon
			GameObject newParent = GameObject.Find ("UpgradeWeaponLocation");
			Upgrade = (Instantiate (Weapon, turretLocation.transform.position, transform.rotation)) as GameObject;
			//Destroy (col.gameObject);//blue floating ballon
			Upgrade.transform.SetParent (newParent.transform, true);
			Upgrade.transform.localScale = new Vector3 (7, 7, 7);
			//newParent.transform = Upgrade.transform.parent;

			SoundEffectsHelper.Instance.MakeReloadGunSound ();
			GameObject ParticleEffect = (Instantiate (particleEffect, this.gameObject.transform.position, transform.rotation)) as GameObject;
			Destroy (col.gameObject);//blue floating ballon
			//Upgrade1 = false;
		}

//		if(col.gameObject.tag == "Weapon" && bulletAmount > 0 && Upgrade == true)
//		{
//			//bulletAmount = 0;
//			Destroy(Upgrade);
//		}
	}

//	void OnTriggerExit2D(Collider2D col)
//	{
//		Debug.Log ("TriggerExit");
//		if (col.gameObject.tag == "Weapon" && bulletAmount < 0) 
//		{
//			Upgrade1 = false;
//			Destroy (col.gameObject);//blue floating ballon
//			Destroy (Upgrade);//weapon sprite
//
//		}
//	}
}
