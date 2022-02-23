using System.IO;

namespace SupportBank
{
    public class SupportBank
    {
        public List<Transactions> Transactions { get; set; }

        public SupportBank(List<Transactions> transactions)
        {
            Transactions = transactions;
        }

        public void getTransaction()
        {
            var lines = System.IO.File.ReadAllLines("./Transactions2014.txt");
            foreach (var line in lines)
            {
                Transactions.Add(new Transactions(line));
            }
        }
    }
}