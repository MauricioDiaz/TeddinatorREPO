using UnityEngine;
using System.Collections;

public class TranslateUpDown : MonoBehaviour {

	public float bounce;
	public float speed;
	public float angle;
	protected float degrees = Mathf.PI/180;

	// Update is called once per frame
	void Update () {
		angle += speed * Time.deltaTime;
		if (angle > 360) 
		{
			angle -= 360;
		}
		transform.position = new Vector3(transform.position.x, bounce * Mathf.Sin (angle * degrees), 0);

		//Ping Pong only goes to axis 0.
		//transform.position = new Vector3( transform.position.x, Mathf.PingPong(Time.time * speed, bounce),transform.position.z);

	}
}
