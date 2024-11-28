using UnityEngine;
using System.Collections;

public class CreateRandomEnemy : MonoBehaviour
{
	public float timer;
	public float newTimer;
	public GameObject enemyPrefab;
	public float numEnemies = 1; // Start with 1 enemy
	public float xMax = 200F;
	public float xMin = 20F;
	public float yMax = -4.5F;
	public float yMin = 3.5F;
	public float increaseInterval = 30f; // Time interval to increase the number of enemies

	void Start()
	{
		// Start the coroutine to increase the number of enemies over time
		StartCoroutine(IncreaseEnemyCount());
	}

	void Update()
	{
		timer -= Time.deltaTime;
		GameObject newParent = GameObject.FindWithTag("SpawnTag");
		if (timer <= 0.0f)
		{
			for (int i = 0; i < numEnemies; i++)
			{
				Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
				GameObject enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
				enemy.transform.parent = newParent.transform;
			}
			timer = newTimer;
		}
	}

	IEnumerator IncreaseEnemyCount()
	{
		while (true)
		{
			yield return new WaitForSeconds(increaseInterval); // Wait for the specified interval
			numEnemies++; // Increase the number of enemies
			Debug.Log("Number of enemies increased to: " + numEnemies);
		}
	}
}
