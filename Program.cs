using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var fileReader = new FileReader();
          List<Transaction> transactions = fileReader.GetTransactions();
          var newBank = new SupportBank(transactions, new List<Account>(){});
          var accounts = newBank.GetAccounts();
        //   newBank.PrintTransactions();
          foreach (var account in accounts)
          {
            newBank.ProvideAccountTransactions(account);
          }
          foreach (var account in accounts)
          {
              Console.WriteLine($"Balance for {account.AccountName}: £" + account.GetBalance());
          }

        }
      
    }
}