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
                Console.WriteLine("Transaction:");
                Console.WriteLine($"    {t.Date}");
                Console.WriteLine($"    from {t.From} to {t.To}");
                Console.WriteLine($"    {t.Narrative}");
                Console.WriteLine($"    Total: {t.Amount}");
            }
        }

        public List<Account> GetAccounts()
        {
            var names = new List<string>(){};
            foreach (Transaction transaction in Transactions)
            {
                if (!names.Contains(transaction.To))
                {
                    names.Add(transaction.To);
                }
                if (!names.Contains(transaction.From))
                {
                    names.Add(transaction.From);
                }

            }
            foreach (string name in names)
            {
                Accounts.Add(new Account(name));
            }
            return Accounts;
        }

    }
}