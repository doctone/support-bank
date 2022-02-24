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
            var target = new FileTarget { FileName = @"C:\Teamwork\support-bank\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            for (int i=1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                Transactions.Add(new Transaction(DateTime.Parse(T[0]),T[1],T[2],T[3],Decimal.Parse(T[4])));
                Logger.Info("Created new transaction"+T[0]);
            }
            return Transactions;
        }
    }
}