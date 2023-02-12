namespace EAUnity.Logging {
	
	public enum LogLevel {
		None = 0,
		Trace = 1, // Even more temporary logs than Debug (Logs in Update, for example)
		Debug = 2, // Used for debugging purposes
		Info = 3,  // Normal Game Logs
		Warn = 4,  // Unexpected behaviour, but not harmful
		Error = 5, 
		Fatal = 6, // Errors that would stop the application
	}

}