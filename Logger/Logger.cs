using System.Diagnostics;

namespace Logger
{
	public class Logger : ILogger
	{
		private ILogStore _store;


		public Logger(ILogStore store)
		{
			_store = store;
		}


		public void Watch(Action action)
		{
			try
			{
				action();
			}
			catch (Exception e)
			{
				Log(e);
			}
		}


		public void Log(Exception e)
		{
			_store.PushLog(new Log(e));
		}


		public void Log(Exception e, string overrideMessage)
		{
			_store.PushLog(new Log(e, overrideMessage));
		}


		public void Log(string message)
		{
			StackTrace stack = new StackTrace();
			_store.PushLog(new Log(message, stack));
		}
	}
}
