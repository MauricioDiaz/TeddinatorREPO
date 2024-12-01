using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[System.Serializable]
public class StoreScript : MBSingleton<StoreScript> {

	public static StoreScript instance;

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

	//tedy skins
	//public Sprite skinOne;
	public Sprite skinChoice;
	public int skinNub;
	public Sprite[] skinSprites;

	void Awake()
	{
		//LOAD
		LoadInformation.LoadAllInfo ();
		//PlayerPrefs.DeleteAll ();//Resets player prefs for testing purpose only on editor
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);

		//myCoins += PlayerControl.instance.points;
		myCoins += GameInformation.PlayerCoins;
		_hp = UpgradedHp;
		_speed = SpeedLimit;
		_shieldTimer = ShieldTimer;
		_ammo = MachineAmmo;
		UpgradedHp = 0;//resets hp to 5 when player looses again
	}

	void Start()
	{
		Coins.text = ("" + myCoins);

		//test to try to save tedy skin between scenes
		DontDestroyOnLoad (this);
		skinChoice = skinSprites [skinNub];



	}

	void Update()
	{
		if (skinNub == 1) 
		{
			skinChoice = skinSprites[0];
		}
		else if (skinNub == 2) 
		{
			skinChoice = skinSprites[1];
		}
		else if (skinNub == 3) 
		{
			skinChoice = skinSprites[2];
		}
		else if (skinNub == 4) 
		{
			skinChoice = skinSprites[3];
		}
		else if (skinNub == 5) 
		{
			skinChoice = skinSprites[4];
		}
		else if (skinNub == 6) 
		{
			skinChoice = skinSprites[5];
		}

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
			GameInformation.PlayerCoins -= 100;
			Coins.text = ("" + myCoins);

			//Save
			SaveInformation.SaveAllInfo ();
			Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
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
			GameInformation.PlayerCoins -= 50;
			Coins.text = ("" + myCoins);

			//Save
			SaveInformation.SaveAllInfo ();
			Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
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
			myCoins -= 100;
			GameInformation.PlayerCoins -= 100;
			Coins.text = ("" + myCoins);

			//Save
			SaveInformation.SaveAllInfo ();
			Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
		}
	}

	public void Ammo()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		if(myCoins >= 200)
		{
			MachineAmmo += 25;
			myCoins -= 200;
			GameInformation.PlayerCoins -= 200;
			Coins.text = ("" + myCoins);

			//Save
			SaveInformation.SaveAllInfo ();
			Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
		}
	}


	//function to update skin
	public void TedyCamoOne()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",1);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;

		Debug.Log (skinNub);

		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}
	//function to update skin
	public void TedyCamoTwo()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",2);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;
		
		Debug.Log (skinNub);
		
		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}
	//function to update skin
	public void TedyCamoThree()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",3);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;
		
		Debug.Log (skinNub);
		
		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}
	public void TedyChewbaca()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",4);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;
		
		Debug.Log (skinNub);
		
		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}
	public void TedyR2D2()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",5);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;
		
		Debug.Log (skinNub);
		
		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}
	public void TedyVader()
	{
		SoundEffectsHelper.Instance.MakeStoreButtonSound ();
		
		PlayerPrefs.SetInt ("Skin",6);
		int skinTempNub = PlayerPrefs.GetInt ("Skin");
		skinNub = skinTempNub;
		
		Debug.Log (skinNub);
		
		//Save
		SaveInformation.SaveAllInfo ();
		Debug.Log("GameInformation Coins" + GameInformation.PlayerCoins);
	}

	public void DebugFunc()
	{
		myCoins += 100;
		Coins.text = ("" + myCoins);
	}
}
