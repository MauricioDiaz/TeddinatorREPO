using UnityEngine;
using System.Collections;

public class CreateIteamScript : MonoBehaviour {

	public float timer;
	public float newTimer;
	public GameObject iteamPrefab;
	public float numIteams;
	public float xMax = 30F;
	public float xMin = 20F;
	public float yMax = -4.5F;
	public float yMin = 3.5F;
	
	void Start () 
	{
		
	}
	
	void Update()
	{
		timer -= Time.deltaTime;
		CreateCoins ();
	}
	
	void CreateCoins()
	{	
		if (timer <= 0.0f) {
			for(int i = 0; i < numIteams; i++)
			{
				GameObject newParent = GameObject.Find ("1_midground-S");
				Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
				
				GameObject coin = Instantiate(iteamPrefab, newPos, Quaternion.identity) as GameObject;
				coin.transform.parent = newParent.transform;
				timer = newTimer;
			}
			
		}
	}
}
