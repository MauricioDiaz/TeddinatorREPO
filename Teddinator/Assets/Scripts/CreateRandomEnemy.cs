using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class CreateRandomEnemy : MonoBehaviour {


	public float timer;
	public float newTimer;
	public GameObject enemyPrefab;
	public float numEnemies;
	public float xMax = 200F;
	public float xMin = 20F;
	public float yMax = -4.5F;
	public float yMin = 3.5F;

	void Update()
	{
		timer -= Time.deltaTime;
		GameObject newParent = GameObject.Find ("1_midground-S");

		if (timer <= 0.0f) {
			for(int i = 0; i < numEnemies; i++)
			{
				Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
				GameObject enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
				enemy.transform.parent = newParent.transform;
				timer = newTimer;
			}

		}
	}

}
