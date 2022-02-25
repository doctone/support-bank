namespace SupportBank
{
    public interface IFileReader
    {
        public List<Transaction> ReadFile(string Path);
    }
}