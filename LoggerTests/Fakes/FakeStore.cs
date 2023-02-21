using Logger;

namespace LoggerTests.Fakes
{
	internal class FakeStore : ILogStore
	{
		public Log? GotLog;

		public void PushLog(Log log)
		{
			GotLog = log;
		}
	}
}
