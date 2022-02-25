using NLog;
using Newtonsoft.Json;

namespace SupportBank
{
    public class JsonReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<JsonTransaction> ReadFile(string path)
        {
            var t = JsonConvert.DeserializeObject<List<JsonTransaction>>(File.ReadAllText(path));
            return t;
        }
    }
}