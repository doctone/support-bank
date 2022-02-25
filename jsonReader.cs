using NLog;
using Newtonsoft.Json;

namespace SupportBank
{
    public class JsonReader : IFileReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> ReadFile(string path)
        {
            var t = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(path));
            return t;
        }
    }
}