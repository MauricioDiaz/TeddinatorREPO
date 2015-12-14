using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	public static string PlayerName{ get; set; }
	public static int PlayerCoins{ get; set; }
	public static int PlayerLives{ get; set; }

	// Use this for initialization
	void Awake () 
	{
		DontDestroyOnLoad (transform.gameObject);

		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);
	}

	void OnApplicationQuit()
	{
		//SAVE
		SaveInformation.SaveAllInfo ();
	}

}
