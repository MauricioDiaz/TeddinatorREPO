using UnityEngine;
using System.Collections;

public class TranslateRightScript : MonoBehaviour {
	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (1, 0) * Time.deltaTime * speed);
	}
}
