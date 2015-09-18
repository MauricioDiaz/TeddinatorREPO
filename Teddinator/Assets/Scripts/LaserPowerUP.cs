using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserPowerUP : MonoBehaviour {

	private float timer = 1;
	public float blastTimer = .005f; 
	public Slider mySlider;
	public bool isfalse = false;
	public GameObject LaserBlast;
	public GameObject blastLocation;
//	public GameObject particleEffect;
//	public GameObject particleEffectLocation;
	private EnemyScript bullet;

	// Use this for initialization
	void Start () {
		//mySlider.value = timer;
		bullet = GetComponent<EnemyScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		mySlider.value = timer;
		timer = timer - blastTimer;
		//Debug.Log (isfalse);
		//Debug.Log (timer);



		if(timer <= 0.0f)
		{
			isfalse = true;
			timer = 1;
			if(isfalse == true)
			{
				//lazer
				GameObject newParent = GameObject.Find("LaserLocation");
				GameObject shoot = (Instantiate(LaserBlast, blastLocation.transform.position, transform.rotation)) as GameObject;
				shoot.transform.SetParent(newParent.transform, true);
				shoot.transform.localScale = new Vector3(10, 10, 10);
				SoundEffectsHelper.Instance.MakeLaserBlastSound();

//				GameObject newParent1 = GameObject.Find("ParticleLaserLocation");
//				ParticleSystem PartEffect = (Instantiate(particleEffect, particleEffectLocation.transform.position,transform.rotation)) as ParticleSystem;
//				PartEffect.transform.parent = newParent1.transform;
//				PartEffect.transform.localScale = new Vector3(120, 120,0);

				//PartEffect.Stop();
			}
		}
		else
		{
			isfalse = false;
		}
	}


}
