namespace Logger
{
	internal interface ILogger
	{
		/// <summary>
		/// Catches thrown exceptions inside a function and log them
		/// </summary>
		/// <param name="action"></param>
		void Watch(Action action);

		/// <summary>
		/// Logs exception
		/// </summary>
		/// <param name="e"></param>
		void Log(Exception e);
		void Log(Exception e, string overrideMessage);
		void Log(string message);
	}
}
