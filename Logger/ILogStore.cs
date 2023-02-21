namespace Logger
{
	public interface ILogStore
	{
		void PushLog(Log log);
	}
}
