using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MBSingleton<Ads> {

	// Use this for initialization
	void Start () 
	{
		Advertisement.Initialize ("1010284", true);
	}
	

	public void PlayAd () 
	{
		Advertisement.Show ();
	}
}
