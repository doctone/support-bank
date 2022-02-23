namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date{get;set;}
        public string From {get;set;}
        public string To {get;set;}
        public string Narrative {get;set;}
        public double Amount {get;set;}


        public Transaction(DateTime date,string from, string to, string narrative, double amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        } 
    }
}