namespace SupportBank
{
    public class Account
        {
            string AccountName { get; set; }

            decimal Balance { get; set; }

            public Account(string accountName, decimal balance)
            {
                AccountName = accountName;
                Balance = balance;
            }
        }
}