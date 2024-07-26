var logger = new ConsoleLogger();
logger.Log("start processing");

var fileLogger = new FileLogger(Path.GetFullPath("./"));
logger.Log("start processing");