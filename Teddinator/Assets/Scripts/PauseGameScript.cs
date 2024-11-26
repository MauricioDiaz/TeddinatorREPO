using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGameScript : MonoBehaviour {

	public static PauseGameScript instance;
//
//	public AudioSource[] music;
//	public GameObject menu;
	public bool paused;

	void Awake()
	{
		instance = this;

	}

	// Use this for initialization
	void Start () {
		paused = false;
		DontDestroyOnLoad (this);
	}
	

	public void PauseGame()
	{
		paused = !paused;

		if(paused)
		{
			Time.timeScale = 0;
			AudioSource gameMusic = GameObject.Find("MusicGameObject").GetComponent<AudioSource>();
			gameMusic.Pause();
			AudioSource gameMusic2 = GameObject.Find("Music").GetComponent<AudioSource>();
			gameMusic2.Pause();
			AudioSource countDown = GameObject.Find("CountDownPanel").GetComponent<AudioSource>();
			countDown.Pause();
			AudioSource pauseSound = GameObject.Find("PauseMenu").GetComponent<AudioSource>();
			pauseSound.Play();
//			music[0].Pause();
//			music[1].Pause();
			CanvasGroup panel = GameObject.Find("PauseMenu").GetComponent<CanvasGroup>();
			panel.alpha = 1;
			panel.interactable = true;
			panel.blocksRaycasts = true;

			this.gameObject.SetActive(false);
			//menu.SetActive(true);
			PlayerControl.instance.fireButton.gameObject.SetActive (false);

		}
		else if(!paused)
		{
			Time.timeScale = 1;
			AudioSource gameMusic = GameObject.Find("MusicGameObject").GetComponent<AudioSource>();
			gameMusic.UnPause();
			AudioSource gameMusic2 = GameObject.Find("Music").GetComponent<AudioSource>();
			gameMusic2.UnPause();
			AudioSource countDown = GameObject.Find("CountDownPanel").GetComponent<AudioSource>();
			countDown.UnPause();
			AudioSource pauseSound = GameObject.Find("PauseMenu").GetComponent<AudioSource>();
			pauseSound.Play();
//			music[0].UnPause ();
//			music[1].UnPause();
			CanvasGroup panel = GameObject.Find("PauseMenu").GetComponent<CanvasGroup>();
			panel.alpha = 0;
			panel.interactable = false;
			panel.blocksRaycasts = false;
			this.gameObject.SetActive(true);
			//menu.SetActive(false);
			PlayerControl.instance.fireButton.gameObject.SetActive (true);
		}
	}

	public void ExitToStart()
	{
//		AudioSource pauseSound = GameObject.Find("PauseMenu").GetComponent<AudioSource>();
//		pauseSound.Play();//level loads too fast to play the pause sound.
		AudioSource gameMusic2 = GameObject.Find("Music").GetComponent<AudioSource>();
		gameMusic2.Play();
		Application.LoadLevel ("Start");
		Time.timeScale = 1;//Fixes bug where when you start again everything is frozen

	}

}
