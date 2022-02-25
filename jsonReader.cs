using NLog;
using Newtonsoft.Json;
using NLog.Config;

namespace SupportBank
{
    public class JsonReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<JsonTransaction> ReadFile(string path)
        {
             var config = new LoggingConfiguration();
            DateTime currentDay = DateTime.Now;
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName =  $@"C:\Users\samjam\Documents\code\Support-bank\logs\SupportBank-{currentDay}.log"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);

            // Apply config    
            LogManager.Configuration = config;
            
            var t = JsonConvert.DeserializeObject<List<JsonTransaction>>(File.ReadAllText(path));
            return t;
        }
    }
}