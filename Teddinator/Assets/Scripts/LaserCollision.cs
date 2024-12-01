using UnityEngine;

public class LaserCollision : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log("Collided with: " + col.gameObject.name);

		// Handle enemies and enemy bullets
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
		{
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col);
			PlayerControl.instance.hp++; // Prevents player from losing hp
			Destroy(col.gameObject); // Destroy the enemy or enemy bullet

			// Prevent gaining HP while the shield is active
			if (PlayerControl.instance.shieldToggle)
			{
				PlayerControl.instance.hp--;
			}
		}

		// Handle pickup objects
		if (col.gameObject.tag == "Coin" || col.gameObject.tag == "Health" || 
			col.gameObject.tag == "ShieldUpgrade" || col.gameObject.tag == "Weapon")
		{
			// Ignores laser and pickup layers
			Physics2D.IgnoreLayerCollision(8, 9, true);
		}
	}
}
