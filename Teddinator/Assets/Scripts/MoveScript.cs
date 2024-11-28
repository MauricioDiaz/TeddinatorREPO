
using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	public Vector2 speed;// = new Vector2(10, 10);
	public Vector2 direction;// = new Vector2(-1, 0);	
	public float pauseTime;
	private Vector2 movement;
		
	void Start()
	{
		StartCoroutine (WaitTime ());
	}
		

//	IEnumerator WaitTime()
//	{
//		//SetMovemenetUp ();
//		yield return new WaitForSeconds (pauseTime);
//		SetMovemenetUp ();
//	}
//	void SetMovemenetUp()
//	{
//
//		movement = new Vector2(speed.x * direction.x,8);
//		Invoke ("SetMovemenetDown", Random.Range(.1f,1f));
//		//yield return new WaitForSeconds (pauseTime);
//	}
//	void SetMovemenetDown()
//	{
//		movement = new Vector2(speed.x * direction.x,-8);
//		Invoke ("SetMovemenetUp", Random.Range(.1f,1f));
//	}
//
//	void FixedUpdate()
//	{
//		// Apply movement to the rigidbody
//		GetComponent<Rigidbody2D>().velocity = movement;
//
//	}

	//----------------Test--------------------

	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(pauseTime);
		StartCoroutine(RandomMovement()); // Start the movement loop
	}

	IEnumerator RandomMovement()
	{
		while (true) //Infinite loop to alternate movement directions ramdomly
		{
			//Randomly pick between setmovementup and setmovementdown
			if (Random.value > .5f) {
				yield return StartCoroutine (SetMovementUp ());
			} 
			else 
			{
				yield return StartCoroutine (SetMovementDown ());
			}
		}
	}

	IEnumerator SetMovementUp()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

//		movement = new Vector2(speed.x * direction.x, 1); // Move up
		yield return new WaitForSeconds(pauseTime); // Wait for 1-2 seconds
		movement = new Vector2(Random.Range(-3,3), Random.Range(-3,3) * speed.x);

	}

	IEnumerator SetMovementDown()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		//movement = new Vector2(speed.x * direction.x, -1); // Move down
		yield return new WaitForSeconds(pauseTime); // Wait for 1-2 seconds
		movement = new Vector2(Random.Range(-3,3), Random.Range(-3,3) * speed.x);
	}

	void FixedUpdate()
	{
		// Apply movement to the Rigidbody2D
		GetComponent<Rigidbody2D>().velocity = movement;

		// Clamp the Y position
		Vector3 clampedPosition = transform.position;
		clampedPosition.y = Mathf.Clamp(clampedPosition.y, -8f, 7f);
		//clampedPosition.x = Mathf.Clamp (clampedPosition.x, 6f, 30f);
		transform.position = clampedPosition;
	}

	//--------------Testing new script------------------

//	public Vector2 speed; // Movement speed
//	public Vector2 boundsX; // Min and Max bounds for X-axis
//	public Vector2 boundsY; // Min and Max bounds for Y-axis
//
//	public Vector2 targetPosition; // Target position for movement
//	public Vector2 movement; // Movement vector
//	private Rigidbody2D rb;
//
//	public float pauseDuration; // Time to pause between movements
//
//	void Start()
//	{
//		rb = GetComponent<Rigidbody2D>();
//		//StartCoroutine(HummingbirdBehavior());
//
//	}
//
//	void Update()
//	{
//		//transform.Translate (new Vector2 (-1,0) * Time.deltaTime * 5);
//	}
//
//
////	IEnumerator HummingbirdBehavior()
////	{
////		while (true) 
////		{
////			// Pick a new random target position within the bounds
////			SetNewTargetPosition();
////			// Move towards the target position
////			//while((Vector2)transform.position != targetPosition)	
////			while (Vector2.Distance(transform.position, targetPosition) > 0.5f) // Use tolerance for comparison
////			{
////				Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
////				movement = Vector2.Scale(direction, speed); // Apply speed to the direction
////				rb.velocity = movement;
////				yield return null; // Wait for the next frame
////			}
////
////			//Debug.Log ("TEST BIRD STOPP");
////			// Stop the hummingbird after reaching the target
////			rb.velocity = Vector2.zero;
////
////			// Wait for a specified pause duration before moving to the next target
////			yield return new WaitForSeconds(pauseDuration);
////		}
////	}
//		
//
//	void SetNewTargetPosition()
//	{
////		float newX = transform.position.x - Random.Range (10f, 20f);//Move left by a randomt amount between 5 and 10
////		float newY = Random.Range (-8.5f, 7f);//Keep the Y position within defined bounds
////
////		newX = Mathf.Max (newX, -10f);//Replace -50f with your left most camera boundary
////
////		targetPosition = new Vector2 (newX,newY);
//
//		float newX = transform.position.x - Random.Range(1f, 5f); // Move left by a random amount
//		float newY = Random.Range(-8.5f, 7f); // Keep the Y position within defined bounds
//
//		// Clamp the newX to prevent it from moving endlessly to the left
//		// Replace -50f and cameraRightBoundary with actual game boundaries
//		float cameraLeftBoundary = 0f;  // Replace with your left-most game boundary
//		float cameraRightBoundary = 30f; // Replace with your right-most game boundary
//
//		newX = Mathf.Clamp(newX, cameraLeftBoundary, cameraRightBoundary);
//
//		targetPosition = new Vector2(newX, newY);
//
//	}

}
