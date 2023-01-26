using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logging {
	public class CustomLogger {

		// Static Usage
		private static LogLevel _level = LogLevel.Debug;
		public static void SetLogLevel(LogLevel level) {
			_level = level;
		}
		
		// Instance Usage
		private readonly string _tag;
		private readonly Object _context;
		private readonly Logger _logger;
		private Dictionary<string, object> _parameters;

		public CustomLogger(string tag, Object context = null) {
			_tag = tag;
			_context = context;
			_parameters = new Dictionary<string, object>();
			_logger = new Logger(UnityEngine.Debug.unityLogger.logHandler);
		}
		
		public void AddParameters(params LogParam[] parameters) {
			foreach (var param in parameters) {
				_parameters.Add(param.Key, param.Value);
			}
		}

		public void RemoveParam(string key) {
			_parameters.Remove(key);
		}

		private string GetParamString() {
			string result = "";
			foreach (var (key, value) in _parameters) {
				result += $"[{key}={value.ToStringFormat()}]";
			}
			return result;
		}

		#region Base Logging Methods
		public void Trace(string message) {
			if (_level > LogLevel.Trace) return;
			_logger.LogFormat(LogType.Log, _context, "{0}: {1} | {2}", _tag.ToUpper(), message, GetParamString());
		}
		
		public void Debug(string message) {
			if (_level > LogLevel.Debug) return;
			_logger.LogFormat(LogType.Log, _context, "{0}: {1} | {2}", _tag.ToUpper(), message, GetParamString());
		}
		
		public void Info(string message) {
			if (_level > LogLevel.Info) return;
			_logger.LogFormat(LogType.Log, _context, "{0}: {1} | {2}".Color(Color.white), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Warn(string message) {
			if (_level > LogLevel.Warn) return;
			_logger.LogFormat(LogType.Warning, _context, "{0}: {1} | {2}".Color(Color.yellow), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Err(string message) {
			if (_level > LogLevel.Error) return;
			_logger.LogFormat(LogType.Error, _context, "{0}: {1} | {2}".Color(Color.red), _tag.ToUpper(), message, GetParamString());
		}
		#endregion
		
	}
	
	public struct LogParam {
		public string Key;
		public object Value;

		public LogParam(string key, object value) {
			Key = key;
			Value = value;
		}
	}
}