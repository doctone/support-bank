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
            
        }
}