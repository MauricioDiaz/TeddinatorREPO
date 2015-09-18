using UnityEngine;
using System.Collections;

public class DestroyWallScript2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Weapon")
		{
			Destroy(col.gameObject);
		}
	}
}
