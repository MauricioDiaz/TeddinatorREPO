﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	public static GameOverScore instance;

	public Text currentScore;
	public Text coinScore;
	public float score = 0;
	public float coins = 0;
	public float timerAmount;
	private bool scoreBool;
	private bool coinsBool;

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

	}

	void Update()
	{


		if(scoreBool == true || coinsBool == true)
		{
//			StartCoroutine ("AddCoins", .001f);
			currentScore.text = ("+" + score);
			coinScore.text = ("" + coins);
		}

		if(score >= PlayerControl.instance.gameOverPoint)//enemies destroyed
		{
			currentScore.text = ("+" + score);
			scoreBool = false;
			StopCoroutine("AddScore");
		}


		if(coins >= PlayerControl.instance.points)//coins collected
		{
			coinScore.text = ("" + coins);
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
