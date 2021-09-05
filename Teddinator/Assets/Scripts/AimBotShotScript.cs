using UnityEngine;
using System.Collections;

public class AimBotShotScript : MonoBehaviour 
{
	//movement


	public Transform player;
	public float speed;

	//damage
	public int damage = 1;
	public int points = 0;

	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 4);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () 
	{		
		transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
	}

}
