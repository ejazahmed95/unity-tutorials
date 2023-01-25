using UnityEngine;

namespace Logging {
	
	public enum LogLevel {
		None = 0,
		Trace = 1, // Even more temporary logs than Debug (Logs in Update, for example)
		Debug = 2, // Used for debugging purposes
		Info = 3,  // Normal Game Logs
		Warn = 4,  // Unexpected behaviour, but not harmful
		Error = 5, 
		Fatal = 6, // Errors that would stop the application
	}

	public static class Log {
		
#if UNITY_EDITOR
		private static LogLevel _level = LogLevel.Debug;
#else
		private static LogLevel _level = LogLevel.Info;
#endif
		
		public static void SetLogLevel(LogLevel level) {
			_level = level;
		}

		public static void Trace(string message) {
			if (_level > LogLevel.Trace) return;
			UnityEngine.Debug.Log($"{message}".Color(Color.gray));
		}
		
		public static void Debug(string message) {
			if (_level > LogLevel.Debug) return;
			UnityEngine.Debug.Log($"{message}");
		}
		
		public static void Info(string message) {
			if (_level > LogLevel.Info) return;
			UnityEngine.Debug.Log($"{message}".Color(Color.white));
		}
		
		public static void Warn(string message) {
			if (_level > LogLevel.Warn) return;
			UnityEngine.Debug.LogWarning($"{message}".Color(Color.yellow));
		}
		
		public static void Err(string message) {
			if (_level > LogLevel.Error) return;
			UnityEngine.Debug.LogError($"{message}".Color(Color.red));
		}
		
		public static void Fatal(string message) {
			UnityEngine.Debug.LogError($"{message}".Color(Color.red));
		}
		
		
	}
}