using System.Collections;
using System.Diagnostics;

namespace Logger
{
	public class Log
	{
		public string[] StackTrace;
		public StackTrace? OriginalStackTrace;
		public string Message;
		public Log? Base;
		public IDictionary? Data;
		public string? Class;


		public Log(Exception exception, string? msg = null)
		{
			Message = msg ?? exception.Message;
			Data = exception.Data;
			Class = exception.GetType().Name;

			StackTrace = exception.StackTrace?.Split('\n') ?? new string[0];
			for (int i = 0; i < StackTrace.Length; i++)
			{
				StackTrace[i] = StackTrace[i].Trim();
			}

			if (exception.InnerException != null)
			{
				Base = new Log(exception.InnerException);
			}
		}


		public Log(string message, StackTrace stack)
		{
			Message = message;
			OriginalStackTrace = stack;
			StackTrace = stack.ToString().Split('\n');
		}
	}
}
