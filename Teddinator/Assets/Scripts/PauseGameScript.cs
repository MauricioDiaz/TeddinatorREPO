using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PauseGameScript : MonoBehaviour {

	public static PauseGameScript instance;

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
		AudioSource music = GetComponent<AudioSource> ();
		AudioSource countdown = GameObject.Find("CountDownPanel").GetComponent<AudioSource>();
		paused = !paused;

		if(paused)
		{
			Time.timeScale = 0;
			music.Pause();
			countdown.Pause();
		}
		else if(!paused)
		{
			Time.timeScale = 1;
			music.Play();
			countdown.Play();
		}
	}
}
