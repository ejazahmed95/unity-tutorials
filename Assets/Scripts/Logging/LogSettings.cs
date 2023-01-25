using System;
using UnityEngine;

namespace Logging {
	public class LogSettings : MonoBehaviour {
		public LogLevel overridenLogLevel = LogLevel.None;

		private void Awake() {
			if (overridenLogLevel != LogLevel.None) {
				Log.SetLogLevel(overridenLogLevel);
			}
		}
	}
}