using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EAUnity.Logging {
    public class LoggingSim : MonoBehaviour {

        public string customLogKey;
        public GameObject customLogValue;

        private PowerLogger _logger;

        // Start is called before the first frame update
        void Start() {
            Random.InitState((int)DateTime.Now.Ticks);
            _logger = PowerLogger.Get($"{gameObject.name}");
            _logger.AddParameters(new LogParam(customLogKey, customLogValue));
            StartCoroutine(StartLogging());
        }

        private IEnumerator StartLogging() {
            while (true) {
                float randomValue = Random.value;
                yield return new WaitForSeconds(0.5f + randomValue);
                switch (randomValue) {
                    case < 0.2f:
                        _logger.Debug($"This is a debug log");
                        break;
                    case < 0.3f:
                        _logger.Info($"This is a normal log");
                        break;
                    case < 0.4f:
                        _logger.Warn($"This is a warning log");
                        break;
                    case < 0.5f:
                        _logger.Err($"This is an error log");
                        break;
                }
            }
        }
        
    }
}
