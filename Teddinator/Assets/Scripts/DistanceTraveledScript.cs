using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTraveledScript : MonoBehaviour {


	public static DistanceTraveledScript instance;

	public Text distance_text;
	//public float distance;

	public float timer;
	public float score = 0;
	public float distanceHighsScore;



	// Use this for initialization
	void Start () 
	{
		distanceHighsScore = PlayerPrefs.GetFloat ("Best Distance");
		//Debug.Log ("distanceHighsScore: " + distanceHighsScore.ToString("0"));
	}
	
	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;
		distance_text.text = ("Distance: " + timer.ToString("F0"));//Keeps decimal number to the tenths
		score = timer;

//		Debug.Log ("timer: " + timer.ToString("0"));
//		Debug.Log ("score: " + score.ToString("0"));
//		Debug.Log ("Distance: " + PlayerPrefs.GetFloat("Best Distance").ToString("0"));
		if(score >= distanceHighsScore)//Distance
		{
			//Debug.Log ("aksjdf;lkajsd;lkfjas;lkdfj;laskdjf;lkasjdfl;kasjdflk;");
			distanceHighsScore = score;
			PlayerPrefs.SetFloat("Best Distance", distanceHighsScore);
		}
	}
}
