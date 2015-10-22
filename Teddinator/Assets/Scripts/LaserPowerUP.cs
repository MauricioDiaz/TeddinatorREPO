using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserPowerUP : MonoBehaviour {

	public float timer = 0;
	public float blastTimer; 
	public float blastLength;
	public Slider mySlider;
	public bool isfalse;
	public bool isFiring;
	public GameObject LaserBlast;
	public GameObject blastLocation;
	private EnemyScript bullet;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<EnemyScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		mySlider.value = timer;
		timer = timer + blastTimer;
		blastLength -= Time.deltaTime; 

		if(timer >= 1.0f)
		{
			isfalse = true;

			if(isfalse == true)
			{
				isFiring = true;
				GameObject newParent = GameObject.Find("LaserLocation");
				GameObject shoot = (Instantiate(LaserBlast, blastLocation.transform.position, transform.rotation)) as GameObject;
				shoot.transform.SetParent(newParent.transform, true);
				shoot.transform.localScale = new Vector3(10, 10, 10);
				SoundEffectsHelper.Instance.MakeLaserBlastSound();
			}
			if(isFiring == true)
			{
				timer = 0;
				blastLength = 3;
				Destroy(GameObject.Find("LaserPrefab(Clone)"), 3f);
				isFiring = false;	
			}
		}
		else
		{
			isfalse = false;
		}
	}
}
