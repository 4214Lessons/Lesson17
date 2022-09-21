using Serilog;

// Serilog
// NLog
// log4net


string format = @"[{Timestamp:HH:mm:ss} {Level:u3}] {Message} {Exception} {MachineName} {ThreadId} {NewLine}";


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("myLog.txt", outputTemplate: format)
    .WriteTo.Console(outputTemplate: format)
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .CreateLogger();


Log.Information("InfoMessage1");
Log.Information("InfoMessage2");
Log.Warning("WarningMessage");
Log.Error(new NullReferenceException("ExMess"), "ErrorMessage");
Log.Fatal("FatalMessage");





new Thread(() => 
{
    Console.WriteLine("Murad");
    Log.Information("Other thread");
}).Start();