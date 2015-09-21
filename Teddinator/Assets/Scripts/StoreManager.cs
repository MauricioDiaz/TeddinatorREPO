using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {

	public delegate void OnStoreScene();
	public static event OnStoreScene onStoreScene;

	public Button storeButton;
	
	public void GoToStore () //called in inspector
	{
		if(onStoreScene != null)
		{
			onStoreScene();
		}
	}
}
