using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 80;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(1 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Retry!"))
		{
			// Reload the level
			Application.LoadLevel("Teddy_Animation_Test_6");
			SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Go to Store"))
		{
			// Reload the level
			Application.LoadLevel("Store");
			SoundEffectsHelper.Instance.MakeOnHoverButtonSound ();
		}
	}
}