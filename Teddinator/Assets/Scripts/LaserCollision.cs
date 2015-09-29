using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
		{
			Destroy(col.gameObject);
			PlayerControl.instance.hp++;
		}

		if(col.gameObject.tag == "Coin" || col.gameObject.tag == "Health" || col.gameObject.tag == "ShieldUpgrade" || col.gameObject.tag == "Weapon")
		{
			Physics2D.IgnoreCollision(this, col.gameObject, true);
			Physics2D.IgnoreLayerCollision(1,2, true);
		}
	}
}
