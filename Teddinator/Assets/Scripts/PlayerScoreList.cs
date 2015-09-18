using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;
	public int ScoreBoardSize = 10;
	ScoreBoardManager scoreManager;
	int lastChangeCounter;

	// Use this for initialization
	void Start () {

		scoreManager = GameObject.FindObjectOfType<ScoreBoardManager> ();

		lastChangeCounter = scoreManager.GetChangeCounter ();

		scoreManager.ChangeScore ("mauri11", "kills", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreManager == null) {
			Debug.Log("You forgot to add the score manager component to a game object!");
			return;
		}

		if(scoreManager.GetChangeCounter() == lastChangeCounter)
		{
			//No change since last update
			return;
		}

		lastChangeCounter = scoreManager.GetChangeCounter ();

		//removes anything we already have
		while (this.transform.childCount> 0) {
			Transform c = this.transform.GetChild (0);
			c.SetParent(null);
			Destroy(c.gameObject);
		}


		string[] names = scoreManager.GetPlayerNames("coins");
		
		//fcreates size of board
		foreach(string name in names) {
			GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
			go.transform.SetParent(this.transform);
			go.transform.Find("Username").GetComponent<Text>().text = name;
			go.transform.Find("Coins").GetComponent<Text>().text = scoreManager.GetScore(name,"coins").ToString();
			go.transform.Find("Kills").GetComponent<Text>().text = scoreManager.GetScore(name,"kills").ToString();

		}
	}
}
