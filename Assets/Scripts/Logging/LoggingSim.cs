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
                switch (randomValue) {
                    case < 0.2f:
                        Log.Debug($"{systemName.Bold()}: This is a debug log");
                        break;
                    case < 0.3f:
                        Log.Info($"{systemName.Bold()}: This is a normal log");
                        break;
                    case < 0.4f:
                        Log.Warn($"{systemName.Bold()}: This is a warning log");
                        break;
                    case < 0.5f:
                        Log.Err($"{systemName.Bold()}: This is an error log");
                        break;
                }
            }
        }
    }
}
