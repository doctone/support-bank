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

        public void ProvideAccountTransactions(Account account)
        {
            foreach (Transaction t in Transactions)
            {
                if (t.To == account.AccountName || t.From == account.AccountName)
                {
                    account.Transactions.Add(t);
                }
            }
        }

        public void ListAll()
        {
            foreach (var account in Accounts)
                {
                    Console.WriteLine($"Balance for {account.AccountName}: £" + account.GetBalance());
                }
        }

    }
}