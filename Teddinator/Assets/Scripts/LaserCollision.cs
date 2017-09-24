using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
		{

			PlayerControl.instance.hp++;//prevents player from loosing hp
			Destroy(col.gameObject);
			if(PlayerControl.instance.shieldToggle == true)
			{
				PlayerControl.instance.hp--;//This is so the player wont get Hp while shiled and laser are active
			}
		}

		if(col.gameObject.tag == "Coin" || col.gameObject.tag == "Health" || col.gameObject.tag == "ShieldUpgrade" || col.gameObject.tag == "Weapon")
		{
			Physics2D.IgnoreLayerCollision(8,9, true);//Ignores laser and pickup layers
		}
	}
}
