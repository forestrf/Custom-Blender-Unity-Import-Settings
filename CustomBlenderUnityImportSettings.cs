using UnityEngine;
using UnityEditor;
using System.IO;

class CustomBlenderUnityImportSettings : AssetPostprocessor {
	void OnPreprocessModel() {
		if (!assetPath.Contains(".blend")) return;

		if (dst == null || replacement == null) Init();

		if (0 == count++) {
			//Debug.Log("Applied custom blender importing settings");
			File.WriteAllText(dst, replacement);
		}
	}

	void OnPostprocessModel(GameObject _) {
		if (!assetPath.Contains(".blend")) return;

		if (--count == 0) {
			//Debug.Log("Restored Unity's original blender importing settings");
			File.WriteAllText(dst, original);
		}
	}

	static int count;
	static string original, replacement;
	static string dst;

	[InitializeOnLoadMethod]
	static void Init() {
		var guids = AssetDatabase.FindAssets("Unity-BlenderToFBX");
		if (guids.Length == 0) throw new System.Exception("Unity-BlenderToFBX.py not found in the project assets, so no copy of it will be performed");

		string guid = guids[0];
		if (guids.Length > 0) {
			foreach (var elem in guids) {
				var path2 = AssetDatabase.GUIDToAssetPath(elem);
				if (path2.StartsWith("Assets")) {
					guid = elem;
					break;
				}
			}
		}

		var path = AssetDatabase.GUIDToAssetPath(guid);
		var src = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/') + 1) + path;
		dst = EditorApplication.applicationContentsPath + "/Tools/Unity-BlenderToFBX.py";

		original = File.ReadAllText(dst);
		replacement = File.ReadAllText(src);
	}
}
