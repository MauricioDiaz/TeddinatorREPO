using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{

	public GameObject GOPanel;
	public GameObject HSPanel;

	public Button retry;
	public Button goToStore;
	public Button highScore;


	//SAVED METHOD
	private void StoreNewPlayerInfo()
	{
		GameInformation.PlayerName = "Mauricio";
		GameInformation.PlayerCoins = PlayerControl.instance.points + GameInformation.PlayerCoins;
		//GameInformation.PlayerLives = PlayerControl.instance.hp + GameInformation.PlayerLives;
	}

	void OnEnable()
	{
		StartCoroutine ("PanelON",.5f);

		//SAVE
		StoreNewPlayerInfo ();
		SaveInformation.SaveAllInfo ();
	}

	IEnumerator PanelON(float time)
	{
		yield return new WaitForSeconds (time);
		GOPanel.SetActive (true);
		
		retry = GameObject.Find ("Retry").GetComponent<Button>();
		goToStore = GameObject.Find ("GoToStore").GetComponent<Button> ();
	}

	public void Retry()//called in inspector
	{
		Application.LoadLevel("Level1");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();

		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);

		//*****************************FUCK YEA!!! THESE LINES BELOW FIXED THE HIGHSCORE BUG!!!!!!!!!!!!!!!!!!!!!
		EnemyHealthScript.tempEnemiesDestroyed = 0;//resets enemies destroyed count when retry is pressed
		EnemyHealthScript.enemiesDestroyed = 0;//resets enemies destroyed count when retry is pressed
		Debug.Log("PlayerPrefs Enemies Destoryed Gameoverscript: " + EnemyHealthScript.tempEnemiesDestroyed);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);
	}

	public void GoToStore()//called in inspector
	{
		Application.LoadLevel ("Store");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();

		//LOAD
		LoadInformation.LoadAllInfo ();
		Debug.Log ("Name " + GameInformation.PlayerName);
		Debug.Log ("Coins " + GameInformation.PlayerCoins);
		//Debug.Log ("Lives " + GameInformation.PlayerLives);
	}

	public void HighScore()
	{
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();

		GameObject gameOverPanel = GameObject.Find ("GameOverPanel");
		gameOverPanel.SetActive (false);

		HSPanel.SetActive (true);
	}

}