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

            public decimal GetBalance()
            {
                decimal Balance = 0;
                foreach (Transaction t in Transactions)
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