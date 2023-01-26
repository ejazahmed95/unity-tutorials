using UnityEngine;

namespace Logging {
	public class LogSettings : MonoBehaviour {
		public LogLevel overridenLogLevel = LogLevel.None;

		private void Awake() {
			if (overridenLogLevel != LogLevel.None) {
				CustomLogger.SetLogLevel(overridenLogLevel);
			}
		}
	}
}