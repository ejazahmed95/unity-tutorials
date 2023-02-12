using System.Collections.Generic;
using UnityEngine;

namespace EAUnity.Logging {
	public class LogSettings : MonoBehaviour {
		public LogLevel overridenLogLevel = LogLevel.None;
		
		public List<LogSettingForLevel> customLevelSettings;
		public List<LogSettingForTag> customTagSettings;
		
		private void Awake() {
			if (overridenLogLevel != LogLevel.None) {
				PowerLogger.SetLogLevel(overridenLogLevel);
			}

			foreach (var setting in customTagSettings) {
				PowerLogger.Get(setting.tag).UpdateSetting(setting);
			}
			
			foreach (var setting in customLevelSettings) {
				PowerLogger.UpdateSetting(setting);
			}
		}
	}
	
}