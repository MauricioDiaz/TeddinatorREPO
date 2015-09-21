using UnityEngine;
using System.Collections;

public abstract class MBSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static bool IsDestroying;
	protected static T instance;
	
	public  static T Instance
	{
		get
		{
			if (instance == null || IsDestroying)
			{
				instance = FindObjectOfType<T>();
				if (instance == null)
				{
					if(!IsDestroying)
					{
						Debug.LogError("Singleton: An instance of " + typeof(T) + " is needed in the scene.");
					}
				}
				else
				{
					IsDestroying = false;
				}
			}
			
			return instance;
		}
	}
	
	public static bool IsInScene {
		get {
			if (instance != null)
				return true;
			else if (null != (instance = FindObjectOfType<T>()))
				return true;
			else
				return false;
		}
	}
	
	public virtual void OnDestroy ()
	{
		IsDestroying = true;
	}
}
