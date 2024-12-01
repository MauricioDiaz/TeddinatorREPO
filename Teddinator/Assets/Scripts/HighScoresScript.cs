using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoresScript : MonoBehaviour {

	public Text distance_text;
	public Text coins_text;
	public Text enemiesDes_text;

//	public int coins;
//	public int enemies;
	public int coinsHighScore;
	public int enemiesDesHighScore;
	public float distanceHighScore;


	void Awake()
	{
		coinsHighScore = PlayerPrefs.GetInt ("Most Coins", 0);
		enemiesDesHighScore = PlayerPrefs.GetInt ("Most Enemies Destroyed",0 );
		distanceHighScore = PlayerPrefs.GetFloat ("Best Distance", 0);
		Debug.Log("Enemies : " + enemiesDesHighScore);
		Debug.Log("Coins : " + coinsHighScore);
		Debug.Log("Distance: " + distanceHighScore);
	}

//	// Use this for initialization
//	void Start () 
//	{
//		//PlayerPrefs.DeleteAll ();//Resets player prefs for testing purpose only on editor
//		coinsHighScore = PlayerPrefs.GetInt ("Most Coins", 0);
//		enemiesDesHighScore = PlayerPrefs.GetInt ("Most Enemies Destroyed",0 );
//		distanceHighScore = PlayerPrefs.GetFloat ("Best Distance", 0);
//
//	}

	void Update()
	{
		distance_text.text = ("Distance: " + distanceHighScore.ToString("0"));
		coins_text.text = ("Coins: " + coinsHighScore);
		enemiesDes_text.text = ("Enemies Destroyed: " + enemiesDesHighScore);
		DisplayHighScores ();
	}

	public void DisplayHighScores()
	{
		
		if(PlayerControl.instance.points > coinsHighScore)//Coins Collected
		{
			coinsHighScore = PlayerControl.instance.points;
			PlayerPrefs.SetInt("Most Coins", coinsHighScore);
			PlayerPrefs.Save();
			Debug.Log("Updated Coins High Score: " + coinsHighScore);
		}

		if(EnemyHealthScript.enemiesDestroyed > enemiesDesHighScore)//Enemies Destroyed
		{
			//EnemyHealthScript.enemiesDestroyed = EnemyHealthScript.tempEnemiesDestroyed;
			enemiesDesHighScore = EnemyHealthScript.enemiesDestroyed;
			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDesHighScore);
			PlayerPrefs.Save();
			Debug.Log("Updated Enemies Destroyed High Score: " + enemiesDesHighScore);
//			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript: " + enemiesDesHighScore);
//			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript: " + EnemyHealthScript.tempEnemiesDestroyed);
		}


		if (DistanceTraveledScript.instance.score >  distanceHighScore)//Distance Traveled
		{
			distanceHighScore = DistanceTraveledScript.instance.distanceHighsScore;
			PlayerPrefs.SetFloat ("Most Distance Traveled", DistanceTraveledScript.instance.distanceHighsScore);
			PlayerPrefs.Save();
			Debug.Log("Updated Distance High Score: " + distanceHighScore);
		}
	}
}
