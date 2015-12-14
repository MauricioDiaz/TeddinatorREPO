using UnityEngine;
using System.Collections;

public class LoadInformation{

	public static void LoadAllInfo()
	{
		GameInformation.PlayerName = PlayerPrefs.GetString ("PLAYER_NAME");
		GameInformation.PlayerCoins = PlayerPrefs.GetInt ("PLAYER_COINS");
		//GameInformation.PlayerLives = PlayerPrefs.GetInt ("PLAYER_LIVES");

//		if(PlayerPrefs.GetString("SAVED_GAME") != null)
//		{
//			GameInformation.Player = (PlayerControl)PlayerPrefSerialization.Load ("SAVED_GAME");
//		}
		Debug.Log ("LOADED!");
	}
}
