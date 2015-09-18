using UnityEngine;
using System.Collections;

public class ParentScript : MonoBehaviour {
	public GameObject laser;

	// Use this for initialization
	void Start () {
		GameObject newParent = GameObject.FindGameObjectWithTag("LaserLocation");
		laser.gameObject.transform.parent = newParent.transform;
		//newParent.transform.localScale.Scale (new Vector3 (10, 10, 10));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
