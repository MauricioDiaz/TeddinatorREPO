using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour {

	public Text one;
	public Text two;
	public Text three;
	public Text go;

	// Use this for initialization
	void Start () {
		StartCoroutine (StartCountDown (1));	
	}
	
	IEnumerator StartCountDown(float sec)
	{
		yield return new WaitForSeconds (sec);
		one.enabled = true;
		yield return new WaitForSeconds (sec);
		one.enabled = false;
		two.enabled = true;
		yield return new WaitForSeconds (sec);
		two.enabled = false;
		three.enabled = true;
		yield return new WaitForSeconds (sec);
		three.enabled = false;
		go.enabled = true;
		yield return new WaitForSeconds (sec);
		go.enabled = false;
	
	}
}
