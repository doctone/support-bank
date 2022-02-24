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
          
          // newBank.ListAll();
          newBank.ListAccount(accounts[0]);
        }
      
    }
}