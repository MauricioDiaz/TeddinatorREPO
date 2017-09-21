﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	public static GameOverScore instance;

	public Text currentScore;
	public Text coinScore;
	public Text distanceText;
	public Text enemysDesText;
	public float score = 0;
	public float coins = 0;
	public float timerAmount;
	public int enemiesDes = 0;
	private bool scoreBool;
	private bool coinsBool;

	public DistanceTraveledScript _distance;


	void Awake()
	{
		instance = this;
	}

	void OnEnable()
	{
		scoreBool = true;
		coinsBool = true;
		SoundEffectsHelper.Instance.MakeErrorSound ();
		StartCoroutine ("AddScore");
		StartCoroutine ("AddCoins");
		//distanceText.text = ("Distance: " + _distance.distanceHighsScore.ToString("F2"));//Displays the HighScore info
		distanceText.text = ("Distance: " + _distance.timer.ToString("F2"));
		enemysDesText.text = ("Enemies Destroyed: " + EnemyHealthScript.enemiesDestroyed);
	}

	void Update()
	{


		if(scoreBool == true || coinsBool == true)
		{
//			StartCoroutine ("AddCoins", .001f);
			currentScore.text = ("+" + score);
			coinScore.text = ("Coins: " + coins);
		}

		if(score >= PlayerControl.instance.gameOverPoint)//enemies destroyed
		{
			currentScore.text = ("+" + score);
			scoreBool = false;
			StopCoroutine("AddScore");
		}


		if(coins >= PlayerControl.instance.points)//coins collected
		{
			coinScore.text = ("Coins: " + coins);
			coinsBool = false;
			StopCoroutine("AddCoins");
		}
	}

	IEnumerator AddScore()
	{
		SoundEffectsHelper.Instance.MakeScoreSound();
		score++;
		Debug.Log ("AddScore");
		yield return new WaitForSeconds (.001f);
		StartCoroutine ("AddScore");
	}
	IEnumerator AddCoins()
	{
		SoundEffectsHelper.Instance.MakeScoreSound();
		coins++;
		Debug.Log ("AddCoins");
		yield return new WaitForSeconds (.001f);
		StartCoroutine ("AddCoins");
	}

}
