using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public class FileReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> GetTransactions(string path)
        {   
            var Transactions = new List<Transaction>();
            var lines = System.IO.File.ReadAllLines(path);

            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName =  @"C:\Teamwork\support-bank\SupportBank.log"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
           config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config    
            LogManager.Configuration = config;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                try
                {
                    Transactions.Add(new Transaction(DateTime.Parse(T[0]), T[1], T[2], T[3], Decimal.Parse(T[4])));
                }
                catch (FormatException e)
                {
                      Logger.Info("Unable to parse Line " + (i + 1), e);
                  //  throw new FormatException("Unable to parse Line " + (i + 1), e);
                
                }
                Logger.Info("Created" + lines[i]);
            }
            return Transactions;
        }
    }
}