using Hangfire.Logging;

namespace HangfireDemoApplication.CustomLoggers;

public class CustomLogger : ILog
{
    public string Name { get; set; }

    public bool Log(Hangfire.Logging.LogLevel logLevel, Func<string> messageFunc, Exception exception = null)
    {
        if (messageFunc == null)
        {
            return logLevel > Hangfire.Logging.LogLevel.Info;
        }

        Console.WriteLine(String.Format("{0}: {1} {2} {3}", logLevel, Name, messageFunc(), exception));

        return true;
    }
}
public class CustomLogProvider : ILogProvider
{
    public ILog GetLogger(string name)
    {
        return new CustomLogger { Name = name };
    }
}
