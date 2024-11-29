//using UnityEngine;
//using System.Collections;
//
//public class LaserCollision : MonoBehaviour {
//
//	void OnTriggerEnter2D(Collider2D col)
//	{
//		Debug.Log ("Collided with: " + col);
//		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
//		{
//
//			PlayerControl.instance.hp++;//prevents player from loosing hp
//			Destroy(col.gameObject);
//			if(PlayerControl.instance.shieldToggle == true)
//			{
//				PlayerControl.instance.hp--;//This is so the player wont get Hp while shiled and laser are active
//			}
//		}
//
//		if(col.gameObject.tag == "Coin" || col.gameObject.tag == "Health" || col.gameObject.tag == "ShieldUpgrade" || col.gameObject.tag == "Weapon")
//		{
//			Physics2D.IgnoreLayerCollision(8,9, true);//Ignores laser and pickup layers
//		}
//	}
//}

using UnityEngine;

public class LaserCollision : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Collided with: " + col.gameObject.name);

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

	void OnDestroy()
	{
		Debug.Log("Laser blast was destroyed!");
	}


}
