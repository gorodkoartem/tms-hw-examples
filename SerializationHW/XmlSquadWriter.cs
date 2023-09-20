using SerializationHW.Models;
using System.Xml.Serialization;

namespace SerializationHW
{
    public class XmlSquadWriter : ISquadWriter
    {
        private readonly string _filePath;

        public XmlSquadWriter(string filePath)
        {
            if(filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (Path.GetExtension(filePath) != ".xml")
            {
                throw new ArgumentException($"{nameof(filePath)} should have xml extension");
            }

            _filePath = filePath;
        }

        public void Write(Squad squad)
        {
            if(squad == null)
            {
                throw new ArgumentNullException(nameof(squad));
            }

            using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(typeof(Squad));
                serializer.Serialize(fileStream, squad);
            }
        }
    }
}
