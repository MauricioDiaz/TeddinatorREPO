using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MBSingleton<Ads> {

	public void PlayAd () 
	{
		Advertisement.Show ();
	}
}
