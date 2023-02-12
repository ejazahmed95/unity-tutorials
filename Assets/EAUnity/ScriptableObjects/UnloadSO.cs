using EAUnity.Logging;
using UnityEngine;

#if UNITY_EDITOR
using EAUnity.Editor;
using UnityEditor;
#endif


namespace EAUnity.ScriptableObjects {
    public class UnloadSO : MonoBehaviour {
        
#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += ResetOnPlayModeChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= ResetOnPlayModeChanged;

        }

        private void ResetOnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                PowerLogger.Get().Debug("PlayMode Changed!");
                EAEditorTools.UnloadBaseScriptableObjects();
            }
        }
#endif
    }
}