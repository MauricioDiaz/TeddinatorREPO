using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTraveledScript : MonoBehaviour {

	public Text distance_text;
	//public float distance;

	public float timer;
	public float score;
	public float distanceHighsScore;



	// Use this for initialization
	void Start () 
	{
		distanceHighsScore = PlayerPrefs.GetFloat ("Best Distance");
	}
	
	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;
		distance_text.text = ("Distance: " + timer.ToString("F0"));//Keeps decimal number to the tenths

		score = timer;
		if(score > distanceHighsScore)//Distance
		{
			distanceHighsScore = score;
			PlayerPrefs.SetFloat("Best Distance", distanceHighsScore);
		}
	}
}
