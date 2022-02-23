namespace SupportBank
{
    public class Account
        {
            public string AccountName { get; set; }
            public List<Transaction> Transactions { get; set; }
            public Account(string accountName)
            {
                AccountName = accountName;
                Transactions = new List<Transaction>();
            }
            public void PrintTransactions()
            {
                Console.WriteLine($"-------------------------------Transactions for {AccountName}");
                foreach (Transaction t in Transactions)
                {
                    Console.WriteLine("Transaction:");
                    Console.WriteLine($"    {t.Date}");
                    Console.WriteLine($"    from {t.From} to {t.To}");
                    Console.WriteLine($"    {t.Narrative}");
                    Console.WriteLine($"    Total: {t.Amount}");
                }
            }
        }
}