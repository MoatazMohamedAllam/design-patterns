public class FileLogger: Logger
{
    private string _path;

    public FileLogger(string path)
    {
        _path = path;
    }
    
    protected override void WriteMessage(string message)
    {
        File.AppendAllText(_path,message + Environment.NewLine);
    }
}