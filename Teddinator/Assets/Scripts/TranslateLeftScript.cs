using UnityEngine;
using System.Collections;

public class TranslateLeftScript : MonoBehaviour {
	public float speed = 5;
	public float direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (-1,direction) * Time.deltaTime * speed);
	}
}
