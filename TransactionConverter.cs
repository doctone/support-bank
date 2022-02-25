namespace SupportBank
{
    public class TransactionConverter
    {
        public List<Transaction> JsonConverter(List<JsonTransaction> jsons)
        {
            var newTs = new List<Transaction>();
            foreach (var t in jsons)
            {
                newTs.Add(new Transaction(t.Date, t.FromAccount, t.ToAccount, t.Narrative, t.Amount));
            }
            return newTs;
        }
    }
}