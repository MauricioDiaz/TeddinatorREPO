using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour 
{
	//movement
	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(1, 0);	
	private Vector2 movement;


	//damage
	public int damage = 1;
	public int points = 0;

	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		 //Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
