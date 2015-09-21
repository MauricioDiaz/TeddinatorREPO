using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
	public Button retry;
	public Button goToStore;

	public GameObject rbutton;
	public GameObject gbutton;

	void OnEnable()
	{
		rbutton.SetActive (true);
		gbutton.SetActive (true);

		retry = GameObject.Find ("Retry").GetComponent<Button>();
		goToStore = GameObject.Find ("GoToStore").GetComponent<Button> ();
	}

	public void Retry()//called in inspector
	{
		Application.LoadLevel("Teddy_Animation_Test_6");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

	public void GoToStore()//called in inspector
	{
		Application.LoadLevel ("Store");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}
}