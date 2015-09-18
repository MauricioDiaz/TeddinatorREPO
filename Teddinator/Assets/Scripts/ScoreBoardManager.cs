using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreBoardManager : MonoBehaviour {

	public string level;

	Dictionary<string, Dictionary<string, int>> playerScore;

	int changeCounter = 0;

	// Use this for initialization
	void Start () 
	{
		SetScore ("mauri11", "coins", 345);
		SetScore ("mauri11", "kills", 0);

		SetScore ("infi17yte33", "coins", 2);
		SetScore ("infi17yte33", "kills", 6540);

		SetScore ("aaa", "coins",43);
		SetScore ("aaa", "kills", 3784);

		SetScore ("aaa", "coins", 633);

		SetScore ("ff", "coins", 234);

		SetScore ("ddd", "coins", 8446);




	}

	void Init()
	{
		if (playerScore != null)
			return;

		playerScore = new Dictionary<string, Dictionary<string, int>> ();
	}


	public int GetScore(string username, string scoreType)
	{
		Init ();

		if(playerScore.ContainsKey(username) == false)
		{
			return 0;
		}

		if(playerScore[username].ContainsKey(scoreType) == false)
		{
			return 0;
		}

		return playerScore [username] [scoreType];
	}

	public void SetScore(string username, string scoreType, int value)
	{
		Init ();

		changeCounter++;

		if(playerScore.ContainsKey(username) == false)
		{
			playerScore[username] = new Dictionary<string, int>();
		}

		playerScore [username] [scoreType] = value;

	}

	public void ChangeScore(string username, string scoreType, int amount)
	{
		Init ();

		int currScore = GetScore (username, scoreType);
		SetScore (username, scoreType, currScore + amount);
	}

	public string[] GetPlayerNames()
	{
		Init ();
		return playerScore.Keys.ToArray();
	}

	public string[] GetPlayerNames(string sortingScoreType)
	{
		Init ();

		//Orders names by greatest coin value(add Linq on top)
		return playerScore.Keys.OrderByDescending (n => GetScore (n, sortingScoreType)).ToArray();
	}



	public void Return_To_Game()
	{
		Application.LoadLevel (level);
	}

	public int GetChangeCounter(){
		return changeCounter;
	}

}
