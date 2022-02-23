using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var newBank = new SupportBank(new List<Transaction>(){}, new List<Account>(){});
          newBank.GetTransactions();
          var accounts = newBank.GetAccounts();
          newBank.PrintTransactions();
          foreach (var account in accounts)
          {
            Console.WriteLine(account.AccountName);
          }

        }
      
    }
}