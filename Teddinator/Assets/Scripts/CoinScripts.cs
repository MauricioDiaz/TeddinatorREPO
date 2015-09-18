using UnityEngine;
using System.Collections;

public class CoinScripts : MonoBehaviour {


	public float speed;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2(-1,0) * Time.deltaTime * speed);

	}


	void OnTriggerEnter2D(Collider2D col)
	{
		//HealthScript Point = col.gameObject.GetComponent<HealthScript>();

		if (col.gameObject.tag == "Player") 
		{
			//Point.points++;
			//Point.myCoins++;
			Destroy (this.gameObject);

		}
	}
}
