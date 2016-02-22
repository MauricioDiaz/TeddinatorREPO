using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public Animator panelClosingAnim;

	public void CloseTutorialPanel()
	{
		//calls mecanim transition to close panel
		panelClosingAnim.SetBool("ClosePanel",true);
	}
}
