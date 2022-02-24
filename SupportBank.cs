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
        public void List(string accountName)
        {
            var ts = GetTransactions(accountName);
            Console.WriteLine($"-------------------------------Transactions for {accountName} -------------------------------");
            foreach (Transaction t in ts)
            {
                Console.WriteLine("Transaction:");
                Console.WriteLine($"    {t.Date}");
                Console.WriteLine($"    from {t.From} to {t.To}");
                Console.WriteLine($"    {t.Narrative}");
                Console.WriteLine($"    Total: {t.Amount}");
            }
        }
        public List<Transaction> GetTransactions(string accountName)
        {
            var personalTransactions = new List<Transaction>();

            foreach (var t in Transactions) {
                if (t.From == accountName || t.To == accountName) 
                {
                    personalTransactions.Add(t);
                } 
            }
            return personalTransactions;
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

        public void ListAll()
        {
            foreach (var account in Accounts)
                {
                    Console.WriteLine($"Balance for {account.AccountName}: £" + GetBalance(account.AccountName));
                }
        }

        public decimal GetBalance(string AccountName)
            {
                var personalTransactions = GetTransactions(AccountName);
                decimal Balance = 0;
                foreach (Transaction t in personalTransactions)
                {
                    if (AccountName == t.To)
                    {
                        Balance += t.Amount;
                    } 
                    else
                    {
                        Balance -= t.Amount;
                    }
                }
                return Balance;
            }

    }
}