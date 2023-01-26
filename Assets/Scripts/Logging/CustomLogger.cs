using UnityEngine;

namespace Logging {
	public class CustomLogger {
		private string _tag;
		private Object _context = null;

		private Logger _logger;
		
		public CustomLogger(string tag, Object context = null) {
			_tag = tag;
			_context = context;
			_logger = new Logger(UnityEngine.Debug.unityLogger.logHandler);
		}

		public void Debug(string message) {
			if (Log.Level > LogLevel.Debug) return;
			_logger.Log(LogType.Log, _tag, message, _context);
		}
		
		public void Info(string message) {
			if (Log.Level > LogLevel.Info) return;
			_logger.Log(LogType.Log, _tag, message.Color(Color.white), _context);
		}
		
		public void Warn(string message) {
			if (Log.Level > LogLevel.Warn) return;
			_logger.Log(LogType.Warning, _tag, message.Color(Color.yellow), _context);
		}
		
		public void Err(string message) {
			if (Log.Level > LogLevel.Error) return;
			_logger.Log(LogType.Error, _tag, message.Color(Color.red), _context);
		}
	}
}