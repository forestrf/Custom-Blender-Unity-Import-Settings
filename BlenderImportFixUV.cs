using UnityEngine;
using UnityEditor;
using System.IO;

public class BlenderImportFixUV : AssetPostprocessor {
	void OnPreprocessModel()
	{
		if (!assetPath.Contains(".blend")) return;

		File.WriteAllText(dst, replacement);
	}

	void OnPostprocessModel(GameObject g)
	{
		File.WriteAllText(dst, original);
	}

	static string original, replacement;
	static string dst;

	[InitializeOnLoadMethod]
	static void Init() {
		var guid = AssetDatabase.FindAssets("Unity-BlenderToFBX");
		if (guid.Length != 1) throw new System.Exception("Unity-BlenderToFBX.py not found in the project assets, so no copy of it will be performed");
		var path = AssetDatabase.GUIDToAssetPath(guid[0]);
		var src = Application.dataPath + path.Substring(path.IndexOf('/'));
		//Debug.Log(src);
		dst = EditorApplication.applicationContentsPath + "/Tools/Unity-BlenderToFBX.py";
		//Debug.Log(dst);

		original = File.ReadAllText(dst);
		replacement = File.ReadAllText(src);
	}
}
