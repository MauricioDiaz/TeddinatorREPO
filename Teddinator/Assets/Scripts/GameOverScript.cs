using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{

	public GameObject GOPanel;

	public Button retry;
	public Button goToStore;

	void OnEnable()
	{
		StartCoroutine ("PanelON",.5f);
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
	}

	public void GoToStore()//called in inspector
	{
		Application.LoadLevel ("Store");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

}