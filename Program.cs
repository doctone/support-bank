using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var newBank = new SupportBank(new List<Transaction>(){});
          newBank.GetTransactions();
          newBank.PrintTransactions();
        }
    }
}