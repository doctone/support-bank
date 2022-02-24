namespace SupportBank
{
    public class FileReader
    {
        public List<Transaction> GetTransactions(string path)
        {   
            var Transactions = new List<Transaction>();
            var lines = System.IO.File.ReadAllLines(path);
            for (int i=1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                Transactions.Add(new Transaction(DateTime.Parse(T[0]),T[1],T[2],T[3],Decimal.Parse(T[4])));
            }
            return Transactions;
        }
    }
}