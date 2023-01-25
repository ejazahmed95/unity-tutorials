using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logging {
    public class LoggingSim : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            Random.InitState((int)DateTime.Now.Ticks);
            StartCoroutine(StartLogging("MyApp"));
            StartCoroutine(StartLogging("Player Controller"));
            StartCoroutine(StartLogging("Gameplay Manager"));
            StartCoroutine(StartLogging("Event Manager"));
        }

        private IEnumerator StartLogging(string systemName) {
            while (true) {
                float randomValue = Random.value;
                yield return new WaitForSeconds(0.5f + randomValue);
                if (randomValue < 0.3f) {
                    Debug.Log($"{systemName.Bold()}: This is a normal log");
                } else if (randomValue < 0.4f) {
                    Debug.LogWarning($"{systemName.Bold()}: This is a warning log".Color(Color.yellow));
                } else if (randomValue < 0.5f) {
                    Debug.LogError($"{systemName.Bold()}: This is an error log".Color(Color.red));
                }
            }
        }
    }
}
