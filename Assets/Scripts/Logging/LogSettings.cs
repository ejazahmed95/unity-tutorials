using System.Collections.Generic;
using UnityEngine;

namespace Logging {
	public class LogSettings : MonoBehaviour {
		public LogLevel overridenLogLevel = LogLevel.None;
		
		public List<LogSettingForLevel> customLevelSettings;
		public List<LogSettingForTag> customTagSettings;
		
		private void Awake() {
			if (overridenLogLevel != LogLevel.None) {
				CustomLogger.SetLogLevel(overridenLogLevel);
			}

			foreach (var setting in customTagSettings) {
				CustomLogger.Get(setting.tag).UpdateSetting(setting.setting);
			}
		}
	}
	
}