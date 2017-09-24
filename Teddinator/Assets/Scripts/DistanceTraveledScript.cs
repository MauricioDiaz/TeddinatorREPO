using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTraveledScript : MonoBehaviour {

	public Text distance_text;
	//public float distance;

	public float timer;
	public float score;
	public float distanceHighsScore;
	public int coinsHighScore;
	public int enemiesDesHighScore;


	// Use this for initialization
	void Start () 
	{
		//distance_text.text = "";
		distanceHighsScore = PlayerPrefs.GetFloat ("Best Distance");
		coinsHighScore = PlayerPrefs.GetInt ("Most Coins");
		enemiesDesHighScore = PlayerPrefs.GetInt ("Most Enemies Destroyed");
	}
	
	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;
		distance_text.text = ("Distance: " + timer.ToString("F0"));//Keeps decimal number to the tenths
		//Debug.Log (timer.ToString ());

		score = timer;
		if(score > distanceHighsScore)//Distance
		{
			distanceHighsScore = score;
			PlayerPrefs.SetFloat("Best Distance", distanceHighsScore);
		}
		if(PlayerControl.instance.points > coinsHighScore)//Coins
		{
			coinsHighScore = PlayerControl.instance.points;
			PlayerPrefs.SetInt("Most Coins", coinsHighScore);
		}
		if(score > enemiesDesHighScore)//Enemies Destroyed
		{
			enemiesDesHighScore = EnemyHealthScript.enemiesDestroyed;
			PlayerPrefs.SetInt("Most Enemies Destroyed", enemiesDesHighScore);
		}
	}
}
