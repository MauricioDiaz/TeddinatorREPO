using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColorFlash : MonoBehaviour {
  
	public Text myText;

	void OnEnable () {

		StartCoroutine ("ColorFlash");
	}

	IEnumerator ColorFlash()
	{
		myText.color = new Color (1, 0, 0);
		yield return new WaitForSeconds (.5f);
		myText.color = new Color (0, 0, 0);
		yield return new WaitForSeconds (.5f);
		StartCoroutine ("ColorFlash");
	}
	

}
