using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour {

	public Text one;
	public Text two;
	public Text three;
	public Text go;
	public GameObject script;

	// Use this for initialization
	void Start () {
		StartCoroutine (StartCountDown (1));
		StartCoroutine (SlowDown (1));
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
		script.SetActive (true);
	}

	IEnumerator SlowDown(float timer)
	{
		timer -= Time.deltaTime;
		ScrollingScript ss = GameObject.Find ("_background_trees").GetComponent<ScrollingScript> ();
		ScrollingScript sss = GameObject.Find ("_Floor").GetComponent<ScrollingScript> ();
		yield return new WaitForSeconds (2f);
		ss.speed.x -= 10;
		ss.speed.y -= 10;
		sss.speed.x -= 10;
		sss.speed.y -= 10;
		yield return new WaitForSeconds (.5f);
		ss.speed.x -= 20;
		ss.speed.y -= 20;
		sss.speed.x -= 20;
		sss.speed.y -= 20;
		yield return new WaitForSeconds (.5f);
		ss.speed.x -= 20;
		ss.speed.y -= 20;
		sss.speed.x -= 20;
		sss.speed.y -= 20;
		yield return new WaitForSeconds (.5f);
		ss.speed.x -= 20;
		ss.speed.y -= 20;
		sss.speed.x -= 20;
		sss.speed.y -= 20;
		yield return new WaitForSeconds (.5f);
		ss.speed.x -= 20;
		ss.speed.y -= 20;
		sss.speed.x -= 20;
		sss.speed.y -= 20;
	}
}
