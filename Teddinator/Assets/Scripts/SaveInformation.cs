using UnityEngine;
using System.Collections;

public class SaveInformation
{

	public static void SaveAllInfo()
	{
		PlayerPrefs.SetString("PLAYER_NAME", GameInformation.PlayerName);
		PlayerPrefs.SetInt("PLAYER_COINS", GameInformation.PlayerCoins);
		//PlayerPrefs.SetInt("PLAYER_LIVES", GameInformation.PlayerLives);

//		if(GameInformation.Player != null)
//		{
//			PlayerPrefSerialization.Save("SAVED_GAME", GameInformation.Player);
//		}
		Debug.Log ("SAVED!");
	}



}
