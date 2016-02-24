using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public Animator panelClosingAnim;
	public Animator teddyAnim;
	public GameObject hummingBird;
	public GameObject joyStick;
	public GameObject part1Panel;
	public GameObject part2Button;
	public GameObject part3Button;
	public GameObject part4Button;
	public GameObject part3Panel;
	public GameObject part4Panel;
	public SpriteRenderer[] joystickRenders;


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
		//Invoke ("StopHummingbird", 3);//Invoke keeps calling it every 3 seconds, only wanted to call it once.
		StartCoroutine ("StopHummingbird", 2);

		part1Panel.SetActive (false);
		part2Button.SetActive (false);
		hummingBird.SetActive (true);
		part3Panel.SetActive(true);
		part3Button.SetActive (true);
		//Turns off the sprite renders in the joystick
		foreach(SpriteRenderer sr in joystickRenders)
		{
			sr.enabled = false;
		}
	}

	public void Part3 ()
	{
		if(hummingBird != null)
			hummingBird.SetActive (false);
		part3Button.SetActive (false);
		part3Panel.SetActive (false);
		part4Panel.SetActive (true);
		part4Button.SetActive (true);
	}

	public void Part4()
	{

	}

	IEnumerator StopHummingbird(float second)
	{
		yield return new WaitForSeconds (second);
		hummingBird.GetComponent<TranslateLeftScript> ().enabled = false;
		hummingBird.GetComponent<BoxCollider2D> ().enabled = true;
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
