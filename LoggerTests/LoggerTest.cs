using LoggerTests.Fakes;

namespace LoggerTests
{
	[TestClass]
	public class LoggerTest
	{
		private readonly FakeStore store = new FakeStore();
		private readonly Logger.Logger logger;


		public LoggerTest()
		{
			logger = new Logger.Logger(store);
		}


		[TestMethod]
		public void ShouldPushLog()
		{
			const string message = "FirstLog";
			logger.Log(message);

			Assert.AreEqual(message, store.GotLog!.Message);
		}


		[TestMethod]
		public void ShouldCatchExceptionInsideAnAction()
		{
			const string message = "InsideOfAction";

			logger.Watch(() =>
			{
				throw new Exception(message);
			});

			Assert.AreEqual(message, store.GotLog!.Message);
		}
	}
}