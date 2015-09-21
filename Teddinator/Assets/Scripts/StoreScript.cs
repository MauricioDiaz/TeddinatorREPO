using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreScript : MBSingleton<StoreScript> {
	public Text Coins;
	public int myCoins;

	public static float SpeedLimit = 20;
	public static float timer = 5;



	void Awake()
	{
		myCoins += HealthScript.instance.points;
	}

	void Update(){
		Coins.text = ("COINS " + myCoins);
	}

	public void Play()
	{
		Debug.Log("Play");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
		Application.LoadLevel("Teddy_Animation_Test_6");
	}

	public void Speed()
	{
		Debug.Log ("Button 1 Pressed");
		SoundEffectsHelper.Instance.MakeStoreButtonSound();
		
		//checks to see if you have enough coins
		if(myCoins >= 100){
			
			SpeedLimit += 10;
			myCoins -= 100;
			Debug.Log ("Speed-------------------------------: " + SpeedLimit );
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
			
			timer += 5;
			myCoins -= 50;
			
		}
		else if(myCoins <= 50)
		{
			Debug.Log("Not Enough Coins Available");
		}
	}

	public void DebugFunc()
	{
		myCoins += 100;
		Debug.Log (myCoins);
	}
}
