using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class CreateHealthSpawn : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float numEnemies;
	public float xMax = 85F;
	public float xMin = 20F;
	public float yMax = -4.5F;
	public float yMin = 3.5F;
	//public bool SpawnHealth;
	
	// Use this for initialization
	void Start()
	{
		GameObject newParent = GameObject.Find ("1_midground-S");
		
		for(int i = 0; i < numEnemies; i++)
		{
			//SpawnHealth = true;
			Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
			GameObject octo = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
			octo.transform.parent = newParent.transform;
			//yield return WaitForSeconds(5);

		}
	}
	//only is going to be run at the start, so theres no need for an update function
}
