using UnityEngine;
using System.Collections;

public class LoadInformation{

	public static void LoadAllInfo()
	{
		GameInformation.PlayerName = PlayerPrefs.GetString ("PLAYER_NAME");
		GameInformation.PlayerCoins = PlayerPrefs.GetInt ("PLAYER_COINS");
		GameInformation.PlayerLives = PlayerPrefs.GetInt ("PLAYER_LIVES");


		Debug.Log ("LOADED!");
	}
}
