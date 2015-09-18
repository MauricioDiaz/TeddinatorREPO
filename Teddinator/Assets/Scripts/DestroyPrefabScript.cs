using UnityEngine;
using System.Collections;

public class DestroyPrefabScript : MonoBehaviour {
	public float destroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, destroy);
	}
}
