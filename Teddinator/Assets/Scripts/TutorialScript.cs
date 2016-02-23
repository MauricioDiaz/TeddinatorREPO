using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public Animator panelClosingAnim;
	public Animator TeddyAnim;

	public void CloseTutorialPanel()
	{
		//calls mecanim transition to close panel
		panelClosingAnim.SetBool("ClosePanel",true);
		StartCoroutine ("TeddyFlyIn", 3);
	}

	public void Quit()
	{
		panelClosingAnim.SetBool("ClosePanel",true);

		StartCoroutine ("LoadLevel", 3);
	}

	IEnumerator LoadLevel(float second)
	{
		yield return new WaitForSeconds (second);
		Application.LoadLevel ("Start");
	}

	IEnumerator TeddyFlyIn(float second)
	{
		yield return new WaitForSeconds (second);
		TeddyAnim.SetBool ("FlyIn", true);
	}
}
