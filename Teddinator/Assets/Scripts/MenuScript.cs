using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{

	void Start()
	{
		SoundEffectsHelper.Instance.MakeMenuSongSound ();
	}

	public void Play()
	{
		Application.LoadLevel ("Level1");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

	public void Store()
	{
		Application.LoadLevel ("Store");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
	}

	public void ExitGame()
	{
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		Application.Quit();
	}


}