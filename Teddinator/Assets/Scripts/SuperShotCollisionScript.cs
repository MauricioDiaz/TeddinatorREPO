using UnityEngine;
using System.Collections;

public class SuperShotCollisionScript : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{


		// Handle enemies and enemy bullets
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
		{
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col);
			Destroy(col.gameObject); // Destroy the enemy or enemy bullet

		}

	}
}

