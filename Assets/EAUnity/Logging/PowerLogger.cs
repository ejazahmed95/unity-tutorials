using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EAUnity.Logging {
	public class PowerLogger {

		// Static Usage
		private static LogLevel _level = LogLevel.Debug;
		private static Dictionary<string, PowerLogger> _loggers = new();
		private static Dictionary<LogLevel, LogSettingForLevel> _levelSettings = new() {
			{LogLevel.Trace, new LogSettingForLevel{level = LogLevel.Warn, messageSetting = new LogSetting{color = Color.gray}}},
			{LogLevel.Debug, new LogSettingForLevel{level = LogLevel.Warn, messageSetting = new LogSetting{color = Color.gray}}},
			{LogLevel.Info, new LogSettingForLevel{level = LogLevel.Warn, messageSetting = new LogSetting{color = new Color(1, 1, 1, 0.9f)}}},
			{LogLevel.Warn, new LogSettingForLevel{level = LogLevel.Warn, messageSetting = new LogSetting{color = new Color(1, 1, 0, 0.9f)}}},
			{LogLevel.Error, new LogSettingForLevel{level = LogLevel.Error, messageSetting = new LogSetting{color = new Color(1, 0, 0, 0.9f)}}},
			{LogLevel.Fatal, new LogSettingForLevel{level = LogLevel.Fatal, messageSetting = new LogSetting{color = new Color(1, 0, 0, 0.9f)}}},
		};
		public static void SetLogLevel(LogLevel level) {
			_level = level;
		}
		
		public static PowerLogger Get(string tag = "") {
			if (_loggers.TryGetValue(tag.ToUpper(), out var logger) == false) {
				logger = new PowerLogger(tag);
				_loggers.Add(tag.ToUpper(), logger);
			}
			return logger;
		}

		public static void UpdateSetting(LogSettingForLevel levelSetting) {
			// _levelSettings.Add(levelSetting.level, levelSetting);
			_levelSettings[levelSetting.level] = levelSetting;
		}
		
		// Instance Usage
		private readonly string _tag;
		private readonly Logger _logger;
		private Dictionary<string, object> _parameters;
		LogSettingForTag _tagSetting;
		private bool _useSetting = false;

		private PowerLogger(string tag, Object context = null) {
			_tag = tag;
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

		public void UpdateSetting(LogSettingForTag tagSetting) {
			_tagSetting = tagSetting;
			_useSetting = true;
		}

		private string GetParamString() {
			string result = "";
			foreach (var (key, value) in _parameters) {
				result += $"[{key.Color(Color.white)}={value.ToStringFormat()}]";
			}
			return result;
		}

		private string ApplyFormatting(string a, LogSetting setting) {
			string result = a.Color(setting.color);
			if (setting.bold) result = result.Bold();
			if (setting.italic) result = result.Italic();
			if (setting.size != 0) result = result.Size(Mathf.Min(32, setting.size));
			return result;
		}

		private string GetFormat(LogLevel level) {
			bool useLevelSetting = _levelSettings.TryGetValue(level, out var setting);
			return $"[{level}]" +
			       $"{(_useSetting? ApplyFormatting("{0}", _tagSetting.tagSetting) : "{0}")}: " +
			       $"{(useLevelSetting? ApplyFormatting("{1}", setting.messageSetting): "{1}")} " +
			       $"{{2}}";
		}

		#region Base Logging Methods
		public void Trace(string message, Object context = null) {
			if (_level > LogLevel.Trace) return;
			_logger.LogFormat(LogType.Log, context, GetFormat(LogLevel.Trace), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Debug(string message, Object context = null) {
			if (_level > LogLevel.Debug) return;
			_logger.LogFormat(LogType.Log, context, GetFormat(LogLevel.Debug), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Info(string message, Object context = null) {
			if (_level > LogLevel.Info) return;
			_logger.LogFormat(LogType.Log, context, GetFormat(LogLevel.Info), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Warn(string message, Object context = null) {
			if (_level > LogLevel.Warn) return;
			_logger.LogFormat(LogType.Warning, context, GetFormat(LogLevel.Warn), _tag.ToUpper(), message, GetParamString());
		}
		
		public void Err(string message, Object context = null) {
			if (_level > LogLevel.Error) return;
			_logger.LogFormat(LogType.Error, context, GetFormat(LogLevel.Error), _tag.ToUpper(), message, GetParamString());
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
	
	[System.Serializable]
	public struct LogSettingForTag {
		public string tag;
		public LogSetting tagSetting;
	}

	[System.Serializable]
	public struct LogSettingForLevel {
		public LogLevel level;
		public LogSetting messageSetting;
	}
	
	[System.Serializable]
	public struct LogSetting {
		public Color color;
		public bool bold;
		public bool italic;
		public ushort size;
	}
}