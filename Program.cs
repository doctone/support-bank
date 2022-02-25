using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public class Program
    {
      private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
      public static void Main(string[] args)
        {
          var config = new LoggingConfiguration();
          DateTime currentDay = DateTime.Now;
          // Targets where to log to: File and Console
          var logfile = new NLog.Targets.FileTarget("logfile") { FileName =  $@"C:\Teamwork\support-bank\logs\SupportBank-{currentDay}.log"};
          var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

          // Rules for mapping loggers to targets            
          config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
          config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

          // Apply config    
          LogManager.Configuration = config;

          Logger.Info($"Starting Program at {currentDay}");

          var fileReader = new FileReader();
          List<Transaction> transactions = fileReader.ReadFile("./DodgyTransactions2015.csv");
          var newBank = new SupportBank(transactions);
          Logger.Info("Creating New Bank");

          foreach (var arg in args)
          {
            if (args[0] != "list")
            {
              return;
            }
            if (args[1] == "all")
            {
              newBank.ListAll();
              return;
            }
            if (args[1] != "all")
            {
              newBank.List(args[1]);
              return;
            }
          }
        }
    }
}