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


	public DistanceTraveledScript _distance;
	public GameOverScore _GOScore;

	// Use this for initialization
	void Start () 
	{
		///PlayerPrefs.DeleteAll ();//Resets player prefs for testing purpose only on editor
		coinsHighScore = PlayerPrefs.GetInt ("Most Coins");
		enemiesDesHighScore = PlayerPrefs.GetInt ("Most Enemies Destroyed");

	}

	void Update()
	{
		distance_text.text = ("Distance: " + _distance.distanceHighsScore.ToString("F0"));
		coins_text.text = ("Coins: " + coinsHighScore);
		enemiesDes_text.text = ("Enemies Destroyed: " + enemiesDesHighScore);
		DisplayHighScores ();
		Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript enemiesDesHighScore: " + enemiesDesHighScore);
	}

	public void DisplayHighScores()
	{
		if(PlayerControl.instance.points > coinsHighScore)//Coins
		{
			coinsHighScore = PlayerControl.instance.points;
			PlayerPrefs.SetInt("Most Coins", coinsHighScore);
		}

		if(EnemyHealthScript.enemiesDestroyed > enemiesDesHighScore)//Enemies Destroyed
		{
			//EnemyHealthScript.enemiesDestroyed = EnemyHealthScript.tempEnemiesDestroyed;
			enemiesDesHighScore = EnemyHealthScript.enemiesDestroyed;
			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDesHighScore);
//			EnemyHealthScript.tempEnemiesDestroyed = 0;
			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript: " + enemiesDesHighScore);
			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript: " + EnemyHealthScript.tempEnemiesDestroyed);
		}

//		else if(EnemyHealthScript.enemiesDestroyed < enemiesDesHighScore)
//		{
//			enemiesDesHighScore -= EnemyHealthScript.tempEnemiesDestroyed;
//			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDesHighScore);
//			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript else if: " + enemiesDesHighScore);
//			Debug.Log("PlayerPrefs Enemies Destoryed Highscorescript else if: " + EnemyHealthScript.tempEnemiesDestroyed);
//		}
	}
}
