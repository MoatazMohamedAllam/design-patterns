public abstract class Logger
{
    //template method (has a steps for some algorithm and enable derived classes to inject what ever implemtation they need for some steps)
    public void Log(string message)
    {
        FormatMessage(message);
        WriteMessage(message);
    }

    protected virtual string FormatMessage(string msg)
    {
        return $"{DateTime.Now}: {msg}";
    }
    protected abstract void WriteMessage(string message);
}