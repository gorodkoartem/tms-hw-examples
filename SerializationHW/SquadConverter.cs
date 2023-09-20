namespace SerializationHW
{
    public class SquadConverter
    {
        private readonly ISquadReader _reader;
        private readonly ISquadWriter _writer;

        public SquadConverter(ISquadReader reader, ISquadWriter writer)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Convert()
        {
            var squad = _reader.Read();
            _writer.Write(squad);
        }
    }
}
