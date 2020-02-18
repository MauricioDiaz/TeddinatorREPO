
using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	public Vector2 speed;// = new Vector2(10, 10);
	public Vector2 direction;// = new Vector2(-1, 0);	

	private Vector2 movement;
		
	void Start()
	{

		SetMovemenetUp ();

	}


	// Update is called once per frame
//	void Update () 
//	{
//		//movement
//		movement = new Vector2(
//		speed.x * direction.x,
//		speed.y * direction.y);
//
//
//	}

	void SetMovemenetUp()
	{

		movement = new Vector2(speed.x * direction.x,8);
		Invoke ("SetMovemenetDown", 1f);
	}
	void SetMovemenetDown()
	{
		movement = new Vector2(speed.x * direction.x,-8);
		Invoke ("SetMovemenetUp", 1f);
	}

	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;

	}

}
