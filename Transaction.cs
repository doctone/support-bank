namespace SupportBank
{
    public class Transactions
    {
        public string TransactionLine { get; set; }

        public Transactions(string transactionLine)
        {
            TransactionLine = transactionLine;
        } 
    }
}