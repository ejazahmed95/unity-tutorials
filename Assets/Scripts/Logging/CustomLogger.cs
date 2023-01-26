using UnityEngine;

namespace Logging {
	public class CustomLogger {

		private string _tag;
		private Object _context = null;
		private Logger _logger;

	#if UNITY_EDITOR 
		private static LogLevel _level = LogLevel.Debug;
	#else
		private static LogLevel _level = LogLevel.Info;
	#endif
		
		public CustomLogger(string tag, Object context = null) {
			_tag = tag;
			_context = context;
			_logger = new Logger(UnityEngine.Debug.unityLogger.logHandler);
		}
		
		public static void SetLogLevel(LogLevel level) {
			_level = level;
		}

		#region Base Logging Methods
		
		public void Trace(string message) {
			if (_level > LogLevel.Trace) return;
			_logger.Log(LogType.Log, _tag, message, _context);
		}
		
		public void Debug(string message) {
			if (_level > LogLevel.Debug) return;
			_logger.Log(LogType.Log, _tag, message, _context);
		}
		
		public void Info(string message) {
			if (_level > LogLevel.Info) return;
			_logger.Log(LogType.Log, _tag, message.Color(Color.white), _context);
		}
		
		public void Warn(string message) {
			if (_level > LogLevel.Warn) return;
			_logger.Log(LogType.Warning, _tag, message.Color(Color.yellow), _context);
		}
		
		public void Err(string message) {
			if (_level > LogLevel.Error) return;
			_logger.Log(LogType.Error, _tag, message.Color(Color.red), _context);
		}

		#endregion
		
	}
}