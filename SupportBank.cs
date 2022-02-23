using System.IO;

namespace SupportBank
{
    public class SupportBank
    {
        public List<Transaction> Transactions { get; set; }

        public SupportBank(List<Transaction> transactions)
        {
            Transactions = transactions;
        }

        public void GetTransactions()
        {
            var lines = System.IO.File.ReadAllLines("./Transactions2014.txt");
            for (int i=1; i < lines.Length; i++)
            {
                string[] T = lines[i].Split(",");
                Transactions.Add(new Transaction(DateTime.Parse(T[0]),T[1],T[2],T[3],Double.Parse(T[4])));
            }
        }

        public void PrintTransactions()
        {
            foreach (var t in Transactions)
            {
                Console.WriteLine(t.To);
            }
        }
    }
}