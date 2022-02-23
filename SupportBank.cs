using System.IO;

namespace SupportBank
{
    public class SupportBank
    {
        public List<Transaction> Transactions { get; set; }

        private List<Account> Accounts { get; set; }

        public SupportBank(List<Transaction> transactions, List<Account> accounts)
        {
            Transactions = transactions;
            Accounts = accounts;
        }

        public List<Transaction> GetTransactions()
        {
            var lines = System.IO.File.ReadAllLines("./Transactions2014.txt");
            for (int i=1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                Transactions.Add(new Transaction(DateTime.Parse(T[0]),T[1],T[2],T[3],Double.Parse(T[4])));
            }
            return Transactions;
        }

        public void PrintTransactions()
        {
            foreach (var t in Transactions)
            {
                Console.WriteLine(t.To);
            }
        }

        public List<Account> GetAccounts()
        {
            foreach (Transaction transaction in Transactions)
            {
                Account acc = new Account(transaction.To);
                Accounts.Add(acc);
                Account acc1 = new Account(transaction.From);
                Accounts.Add(acc1);
                Accounts = Accounts.Distinct().ToList();

            }
            return Accounts;
        }

    }
}