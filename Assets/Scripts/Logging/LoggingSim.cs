using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logging {
    public class LoggingSim : MonoBehaviour {
        // Start is called before the first frame update
        
        void Start() {
            Random.InitState((int)DateTime.Now.Ticks);
            StartCoroutine(StartLogging());
        }

        private IEnumerator StartLogging() {
            while (true) {
                float randomValue = Random.value;
                yield return new WaitForSeconds(0.5f + randomValue);
                switch (randomValue) {
                    case < 0.2f:
                        Log.Debug($"{gameObject.name}: This is a debug log");
                        break;
                    case < 0.3f:
                        Log.Info($"{gameObject.name}: This is a normal log");
                        break;
                    case < 0.4f:
                        Log.Warn($"{gameObject.name}: This is a warning log");
                        break;
                    case < 0.5f:
                        Log.Err($"{gameObject.name}: This is an error log");
                        break;
                }
            }
        }
    }
}
