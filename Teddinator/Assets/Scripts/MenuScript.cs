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

	public void ButtonPressed()
	{
		if(gameObject.name == "Play")
		{
		Application.LoadLevel ("Teddy_Animation_Test_6");
		SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		}
		else if(gameObject.name == "HighScores")
		{
			Application.LoadLevel ("ScoreBoard");
			SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		}

	}


}