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
            DateTime currentDay = DateTime.Now;
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName =  $@"C:\Users\samjam\Documents\code\Support-bank\SupportBank-{currentDay}.log"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);

            // Apply config    
            LogManager.Configuration = config;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                DateTime date;
                decimal Amount;

                try {
                    date = DateTime.Parse(T[0]);
                }
                catch (FormatException e)
                {
                    Logger.Error($"'{T[0]}' is not a valid date on line " + (i+1), e);
                    throw new FormatException($"Unable to parse date on line " + (i+1), e);
                }

                try {
                    Amount = decimal.Parse(T[4]);
                }
                catch (FormatException e)
                {
                    Logger.Error($"'{T[4]}' was not recognised as a valid amount.", e);
                    throw new FormatException($"'{T[4]}'was not recognised as a valid amount.", e);
                }

                try
                {
                    Transactions.Add(new Transaction(date, T[1], T[2], T[3], Amount));
                }
                catch (FormatException e)
                {
                    Logger.Error("Unable to parse Line " + (i + 1), e);
                    throw new FormatException("Unable to parse Line " + (i + 1), e);
                
                }
                Logger.Info("Created" + lines[i]);
            }
            return Transactions;
        }
    }
}