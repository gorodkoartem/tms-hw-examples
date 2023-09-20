using SerializationHW.Models;
using System.Text.Json;

namespace SerializationHW
{
    public class JsonSquadReader : ISquadReader
    {
        private readonly string _filePath;

        public JsonSquadReader(string filePath)
        {
            if(filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if(!File.Exists(filePath))
            {
                throw new ArithmeticException($"Specified {nameof(filePath)}({filePath}) doesn't exist");
            }

            _filePath = filePath;
        }

        public Squad Read()
        {
            var source = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<Squad>(source);
        }
    }
}
