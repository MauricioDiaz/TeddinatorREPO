using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParticleParentScript : MonoBehaviour {

	public GameObject particleEffect;
	public GameObject particleEffectLocation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject newParent1 = GameObject.Find("ParticleLaserLocation");
		ParticleSystem PartEffect = (Instantiate(particleEffect, this.transform.position,transform.rotation)) as ParticleSystem;
		PartEffect.transform.parent = newParent1.transform;
		PartEffect.transform.localScale = new Vector3(120, 120,0);
		Destroy (PartEffect, 3);
	}
}
