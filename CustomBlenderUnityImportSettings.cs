using UnityEngine;
using UnityEditor;
using System.IO;

class CustomBlenderUnityImportSettings : AssetPostprocessor {
	void OnPreprocessModel() {
		if (!assetPath.Contains(".blend")) return;

		File.WriteAllText(dst, replacement);
	}

	void OnPostprocessModel(GameObject _) {
		File.WriteAllText(dst, original);
	}

	static string original, replacement;
	static string dst;

	[InitializeOnLoadMethod]
	static void Init() {
		var guids = AssetDatabase.FindAssets("Unity-BlenderToFBX");
		if (guids.Length == 0) throw new System.Exception("Unity-BlenderToFBX.py not found in the project assets, so no copy of it will be performed");

		string guid = guids[0];
		foreach (var elem in guids) {
			if (elem.StartsWith("Assets")) {
				guid = elem;
				break;
			}
		}

		var path = AssetDatabase.GUIDToAssetPath(guid);
		var src = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/') + 1) + path;
		dst = EditorApplication.applicationContentsPath + "/Tools/Unity-BlenderToFBX.py";

		original = File.ReadAllText(dst);
		replacement = File.ReadAllText(src);
	}
}
