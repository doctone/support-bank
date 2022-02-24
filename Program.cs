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
          
          newBank.ListAll();
          newBank.PrintTransactions("Ben B");

        }
        public static void List(SupportBank bank)
        {
          Console.WriteLine("1. List All");
          Console.WriteLine("2. List Account");

          var input = Console.ReadLine();

          if ( input == "1" )
          {
            bank.ListAll();
          } else if 
          ( input == "2" )
          {
            Console.WriteLine("Which account would you like to view?");
            var accounts = bank.GetAccounts();
            foreach (Account account in accounts)
            {
              Console.WriteLine(account.AccountName);
            }
            var nameChoice = Console.ReadLine();
            // bank.ListAccount(nameChoice)
          }
        }
    }
}