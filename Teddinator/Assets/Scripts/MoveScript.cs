
using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	public Vector2 speed;// = new Vector2(10, 10);
	public Vector2 direction;// = new Vector2(-1, 0);	

	private Vector2 movement;
		
	void Start()
	{
		StartCoroutine (WaitTime ());
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

	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds (2);
		SetMovemenetUp ();
	}
	void SetMovemenetUp()
	{

		movement = new Vector2(speed.x * direction.x,8);
		Invoke ("SetMovemenetDown", Random.Range(.1f,1f));
	}
	void SetMovemenetDown()
	{
		movement = new Vector2(speed.x * direction.x,-8);
		Invoke ("SetMovemenetUp", Random.Range(.1f,1f));
	}

	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;

	}

}
