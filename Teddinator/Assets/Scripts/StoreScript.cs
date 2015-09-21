using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreScript : MBSingleton<StoreScript> {
	public Text Coins;
	public int myCoins;

	public static int UpgradedHp;
	public int _hp;

	public static float SpeedLimit;
	public float _speed;

	public static float ShieldTimer;
	public float _shieldTimer;

	void Awake()
	{
		myCoins += HealthScript.instance.points;
		_hp = UpgradedHp;
		_speed = SpeedLimit;
		_shieldTimer = ShieldTimer;
		UpgradedHp = 0;//resets hp to 5 when player looses again
	}

	void Update(){
		Coins.text = ("COINS " + myCoins);
	}

	public void Play()
	{
		Debug.Log("Play");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
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
			
			ShieldTimer += 5;
			myCoins -= 50;
			
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
		}
	}

	public void DebugFunc()
	{
		myCoins += 100;
		Debug.Log (myCoins);
	}
}
