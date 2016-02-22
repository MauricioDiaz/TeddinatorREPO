﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	public void Play()
	{

		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);

		Application.LoadLevel ("Level1");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

	public void Store()
	{

		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);

		Application.LoadLevel ("Store");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

	public void ExitGame()
	{
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		Application.Quit();
	}

	public void Tutorial()
	{
		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);
		
		Application.LoadLevel ("Tutorial");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}


}