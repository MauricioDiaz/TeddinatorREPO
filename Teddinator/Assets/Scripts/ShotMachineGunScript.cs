using UnityEngine;
using System.Collections;

public class ShotMachineGunScript : MonoBehaviour 
{
	//movement
//	public Vector2 speed = new Vector2(10, 10);
//	
//	public Vector2 direction = new Vector2(1, 0);	
//	private Vector2 movement;
	
	
	//damage
	public int damage = 1;
	public int points = 0;
	//private HealthScript healthHp;
	public bool isEnemyShot = false;

	void Start()
	{
		//healthHp = GetComponent<HealthScript> ();
	}
	
//	void OnTriggerEnter2D(Collider2D collider)
//	{
//		if (healthHp != null)
//		{
//			//If enemy crashes with laser this will prevent it from loosing Hp
//			if(collider.gameObject.tag == "Enemy")
//			{
//				Destroy(collider.gameObject);
//				healthHp.hp++;
//			}
//		}
//	}
}