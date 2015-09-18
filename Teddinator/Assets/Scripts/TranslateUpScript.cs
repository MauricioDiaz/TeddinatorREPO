using UnityEngine;
using System.Collections;

public class TranslateUpScript : MonoBehaviour {
	public float speed = 5;
	private float timer = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (timer);
		timer -= Time.deltaTime;
		if(timer >= 1.5){
			transform.Translate (new Vector3 (0, Random.value, 0) * Time.deltaTime * speed);
		}
		else if(timer <= 1.5){
			transform.Translate (new Vector3 (0, Random.value, 0) * Time.deltaTime * speed);
		}
		if(timer <= 0){
			timer = 3;
		}
	}
}
