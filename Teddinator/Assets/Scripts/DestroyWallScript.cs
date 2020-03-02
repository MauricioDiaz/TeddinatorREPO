using UnityEngine;
using System.Collections;

public class DestroyWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Coin")
		{
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "Health")
		{
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "Weapon")
		{
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "ShieldUpgrade")
		{
			Destroy(col.gameObject);
		}
	}

}
