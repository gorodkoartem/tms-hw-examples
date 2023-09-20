using SerializationHW.Models;
using System.Text.Json;

namespace SerializationHW
{
    internal class Program
    {
        private static readonly Dictionary<DirectoryValidationErrorType, string> DirectoryValidationErrorMessages = new Dictionary<DirectoryValidationErrorType, string>
        {
            { DirectoryValidationErrorType.DirectoryIsNotSpecified, "Directory is not specified"},
            { DirectoryValidationErrorType.NonExistingDirectory, "Specified directory doesn't exist"},
            { DirectoryValidationErrorType.EmptyDirectory, "Specified directory is empty"},
            { DirectoryValidationErrorType.MultipleFilesInDirectory, "Specified directory contains more than 1 json file"},
        };

        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("error message");
            }

            var validationResult = ValidateDirectory(args[0]);
            if (!validationResult.Succeeded)
            {
                Console.WriteLine(DirectoryValidationErrorMessages[validationResult.ErrorType]);
                return;
            }

            var directory = args[0];
            var jsonFileName = Directory.GetFiles(directory, "*.json", SearchOption.TopDirectoryOnly)[0];
            var xmlFileName = Path.ChangeExtension(jsonFileName, ".xml");

            var squadConverter = new SquadConverter(
                new JsonSquadReader(jsonFileName),
                new XmlSquadWriter(xmlFileName));

            try
            {
                squadConverter.Convert();
                Console.WriteLine($"Squad from {jsonFileName} was converted to {xmlFileName}");
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid json file");
            }
        }

        private static (bool Succeeded, DirectoryValidationErrorType ErrorType) ValidateDirectory(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                return (false, DirectoryValidationErrorType.DirectoryIsNotSpecified);
            }

            if (!Directory.Exists(directory))
            {
                return (false, DirectoryValidationErrorType.NonExistingDirectory);
            }

            var jsonFiles = Directory.GetFiles(directory, "*.json", SearchOption.TopDirectoryOnly);
            if (!jsonFiles.Any())
            {
                return (false, DirectoryValidationErrorType.EmptyDirectory);
            }

            if (jsonFiles.Length > 1)
            {
                return (false, DirectoryValidationErrorType.MultipleFilesInDirectory);
            }

            return (true, DirectoryValidationErrorType.None);
        }
    }
}