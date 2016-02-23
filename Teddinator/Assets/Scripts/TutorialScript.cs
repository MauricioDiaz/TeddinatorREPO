using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public Animator panelClosingAnim;
	public Animator teddyAnim;
	public GameObject part1Panel;
	public GameObject joyStick;
	public GameObject part2Button;
	public GameObject part3Button;
	public GameObject hummingBird;


	public void CloseTutorialPanel()
	{
		//calls mecanim transition to close panel
		panelClosingAnim.SetBool("ClosePanel",true);
		StartCoroutine ("TeddyFlyIn", 2);
	}

	public void Quit()
	{
		panelClosingAnim.SetBool("ClosePanel",true);

		StartCoroutine ("LoadLevel", 3);
	}

	public void Part2 ()
	{
		part1Panel.SetActive (false);
		joyStick.SetActive (false);
		part2Button.SetActive (false);
		part3Button.SetActive (true);
		hummingBird.SetActive (true);

		//Invoke ("StopHummingbird", 3);//Invoke keeps calling it every 3 seconds, only wanted to call it once.
		StartCoroutine ("StopHummingbird", 2);
	}

	public void Part3 ()
	{
		part3Button.SetActive (false);
	}

	IEnumerator StopHummingbird(float second)
	{
		yield return new WaitForSeconds (second);
		hummingBird.GetComponent<TranslateLeftScript> ().enabled = false;
	}

	IEnumerator LoadLevel(float second)
	{
		yield return new WaitForSeconds (second);
		Application.LoadLevel ("Start");
	}

	IEnumerator TeddyFlyIn(float second)
	{
		yield return new WaitForSeconds (second);
		teddyAnim.SetBool ("FlyIn", true);

		yield return new WaitForSeconds (second);
		part1Panel.SetActive (true);
		joyStick.SetActive (true);
		part2Button.SetActive (true);

		//turns off PlayerControl script to prevent shooting
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ().enabled = true;

		yield return new WaitForSeconds (second);//Prevents shield bug to turn on

		//turns on shield because it is defaulted off.
		GameObject.FindGameObjectWithTag ("Player").transform.FindChild ("ShockwavePlayer").gameObject.SetActive (true);
		teddyAnim.enabled = false;
	}
}
