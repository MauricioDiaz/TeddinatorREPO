using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class StoreScript : MBSingleton<StoreScript> {
	public Text Coins;
	public int myCoins;

	public static int UpgradedHp;
	public int _hp;

	public static float SpeedLimit;
	public float _speed;

	public static float ShieldTimer;
	public float _shieldTimer;

	public static int MachineAmmo;
	public int _ammo;

	void Awake()
	{
		myCoins += PlayerControl.instance.points;
		_hp = UpgradedHp;
		_speed = SpeedLimit;
		_shieldTimer = ShieldTimer;
		_ammo = MachineAmmo;
		UpgradedHp = 0;//resets hp to 5 when player looses again
	}

	void Start()
	{
		Coins.text = ("COINS " + myCoins);
	}


	public void Play()
	{
		Debug.Log("Play");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
		//Plays the add in inspector
		Application.LoadLevel("Level1");
	}

	public void Speed()
	{
		Debug.Log ("Button 1 Pressed");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
		
		//checks to see if you have enough coins
		if(myCoins >= 100){
			
			SpeedLimit += 2.5f;
			myCoins -= 100;
			Coins.text = ("COINS " + myCoins);
		}
		else if(myCoins <= 100)
		{
			Debug.Log("Not Enough Coins Available");
		}
	}

	public void Shield()
	{
		Debug.Log("Button 7 Pressed");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
		//checks to see if you have enough coins
		if(myCoins >= 50){
			
			ShieldTimer += 2.5f;
			myCoins -= 50;
			Coins.text = ("COINS " + myCoins);
		}
		else if(myCoins <= 50)
		{
			Debug.Log("Not Enough Coins Available");
		}
	}

	public void LifeUp()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		if(myCoins >= 100)
		{	
			UpgradedHp++;
			myCoins   -= 100;
			Coins.text = ("COINS " + myCoins);
		}
	}

	public void Ammo()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		if(myCoins >= 200)
		{
			MachineAmmo += 25;
			myCoins -= 200;
			Coins.text = ("COINS " + myCoins);
		}
	}

	public void DebugFunc()
	{
		myCoins += 100;
		Coins.text = ("COINS " + myCoins);
	}
}
