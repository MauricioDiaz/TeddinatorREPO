using UnityEngine;
using System.Collections; 
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerPrefSerialization{

	public static BinaryFormatter binaryForm = new BinaryFormatter();

	public static void Save(string saveTag, object player)
	{

		MemoryStream memoryStream = new MemoryStream ();
		binaryForm.Serialize (memoryStream, player);
		string temp = System.Convert.ToBase64String (memoryStream.ToArray ());

		PlayerPrefs.SetString (saveTag, temp);
	}

	public static object Load(string saveTag)
	{
		string temp = PlayerPrefs.GetString (saveTag);
		if(temp == string.Empty)
		{
			return null;
		}

		MemoryStream memoryStream = new MemoryStream (System.Convert.FromBase64String(temp));
		return binaryForm.Deserialize(memoryStream);
	}

}
