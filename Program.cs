using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var fileReader = new FileReader();
          List<Transaction> transactions = fileReader.GetTransactions("./Transactions2014.txt");
          var newBank = new SupportBank(transactions, new List<Account>(){});
          var accounts = newBank.GetAccounts();
        //   newBank.PrintTransactions();
          foreach (var account in accounts)
          {
            newBank.ProvideAccountTransactions(account);
          }
          newBank.ListAll();
          newBank.PrintTransactions("Ben B");

        }
      
    }
}