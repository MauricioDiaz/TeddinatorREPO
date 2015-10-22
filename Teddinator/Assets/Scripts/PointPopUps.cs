using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointPopUps : MonoBehaviour {

	public static PointPopUps instance;

	public Text coinScore;
	public Canvas PopUpCanvas;
	public int _point;

	void Awake()
	{
		instance = this;
		coinScore = GameObject.Find ("PointPopUp").GetComponent<Text>();
		PopUpCanvas = GameObject.Find ("PopUpCanvas").GetComponent<Canvas>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
//		if(col.gameObject.tag == "Coin")
//		{
//			Text popUp;
//			Vector3 pos = new Vector3(-2f, 1f, 0f);
//			popUp = Instantiate(coinScore, col.transform.position + pos, Quaternion.identity)as Text;
//			popUp.transform.parent = PopUpCanvas.transform;
//			popUp.text = ("1");
//			popUp.color = new Color( Random.value,Random.value,Random.value);
//			Destroy(popUp,.3f);
//		}

		if(col.gameObject.tag == "Enemy")
		{
			Text popUp;
			Vector3 pos = new Vector3(0f, 1f, 0f);
			popUp = Instantiate(coinScore, col.transform.position + pos, Quaternion.identity)as Text;
			popUp.transform.parent = PopUpCanvas.transform;
			popUp.text = ("10");
			popUp.color = new Color( Random.value,Random.value,Random.value);
			Destroy(popUp,.3f);

			_point = 10;
			PlayerControl.instance.points += 10;
			PlayerControl.instance.ScoreText.text = ("" + PlayerControl.instance.points);
		}
//		if(col.gameObject.tag == "")
//		{
//			
//		}
//		if(col.gameObject.tag == "")
//		{
//			
//		}


	}
}
