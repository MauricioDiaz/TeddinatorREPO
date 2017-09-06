using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTraveledScript : MonoBehaviour {

	public Text distance_text;
	//public float distance;

	public float timer;




	// Use this for initialization
	void Start () 
	{
		distance_text.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;
		distance_text.text = ("Distance: " + timer.ToString("F2"));//Keeps decimal number to the tenths
		//Debug.Log (timer.ToString ());

	
	}
}
