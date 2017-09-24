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

	// Use this for initialization
	void Start () 
	{
		coinsHighScore = PlayerPrefs.GetInt ("Most Coins");
		enemiesDesHighScore = PlayerPrefs.GetInt ("Most Enemies Destroyed");
		GameOverScore.instance.enemysDesText.text = ("Enemies Destroyed: " + GameOverScore.instance.enemiesDes);
		GameOverScore.instance.enemiesDes = 0;
//		GameOverScore.instance.enemiesDes = EnemyHealthScript.enemiesDestroyed;
	}


	// Update is called once per frame
	void Update () 
	{
		distance_text.text = ("Distance: " + _distance.distanceHighsScore.ToString("F0"));
		coins_text.text = ("Coins: " + coinsHighScore);
		enemiesDes_text.text = ("Enemies Destroyed: " + enemiesDesHighScore);

		if(PlayerControl.instance.points > coinsHighScore)//Coins
		{
			coinsHighScore = PlayerControl.instance.points;
			PlayerPrefs.SetInt("Most Coins", coinsHighScore);
		}
		if(EnemyHealthScript.enemiesDestroyed > enemiesDesHighScore)//Enemies Destroyed
		{
			enemiesDesHighScore = EnemyHealthScript.enemiesDestroyed;
			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDesHighScore);
		}
	}
}
