using UnityEditor;
using UnityEngine;

namespace EAUnity.Editor {

    public class EAEditorTools {
        [MenuItem("EATools/UnloadScriptableObjects")]
        public static void UnloadBaseScriptableObjects() {
#if UNITY_EDITOR

            Debug.Log("EA Tools");
            string[] guids = AssetDatabase.FindAssets("t:BaseSO");
            int count = guids.Length;
            Debug.Log($"Total Objects = {count}");

            for (var i = 0; i < count; i++) {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

                Debug.Log($"Unloading Asset! Name = {obj.name}");

                Resources.UnloadAsset(obj);
            }
#endif
        }
    }
}