using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var newBank = new SupportBank(new List<Transactions>(){});
          newBank.getTransaction();
          foreach (var transaction in newBank.Transactions)
          {
              Console.WriteLine(transaction.TransactionLine);
          }
        }
    }
}