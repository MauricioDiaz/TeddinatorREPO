using UnityEngine;
using System.Collections;

public class PauseGameScript : MonoBehaviour {

	public static PauseGameScript instance;

	public AudioSource[] music;
	public bool paused;

	void Awake()
	{
		instance = this;

	}

	// Use this for initialization
	void Start () {
		paused = false;
	}
	

	public void PauseGame()
	{
		paused = !paused;

		if(paused)
		{
			Time.timeScale = 0;
			music[0].Pause();
			music[1].Pause();
//			music.Pause();
			//countdown.Pause();
		}
		else if(!paused)
		{
			Time.timeScale = 1;
			music[0].UnPause ();
			music[1].UnPause();
//			music.Play();
			//countdown.Play();
		}
	}
}
