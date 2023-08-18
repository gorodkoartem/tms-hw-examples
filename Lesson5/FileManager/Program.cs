using System.Text;

namespace FileManager
{
    internal static class Program
    {
        private const string EmptySourceError = "Empty source.";
        private const string ThereIsNothingToUpdate = "There is nothing to update";
        private const string SourceIsUpdated = "Source is updated";

        private const char ExclamationMark = '!';
        private const char QuestionMark = '?';

        private static readonly char[] SentenceChars = new char[] { '.', ExclamationMark, QuestionMark };
        private static readonly char[] PunctiationChars = new char[] { ',', '-', ':', '(', ')', ';' };
        private static readonly char[] SpaceChars = new char[] { ' ', '\n', '\"' };

        internal static int Main(string[] args)
        {
            if (!TryGetFileNameFromArgs(args, out var fileName))
            {
                const string FileNameArgValidationFailed = "Unable to find file or it's not speciefied";
                Console.WriteLine(FileNameArgValidationFailed);
                return 1;
            }

            MenuAction action;
            do
            {
                ShowMenu();
                action = GetUserMenuAction(Console.ReadLine());
                Console.WriteLine(ExecuteActionOnFile(action, fileName));
            }
            while (action != MenuAction.Exit);
            return 0;
        }

        private static void ShowMenu()
        {
            const string ChooseActionMessage = "Please choose action (enter any symbol out of menu to exit):";

            Console.WriteLine(ChooseActionMessage);
            var allActions = Enum.GetValues<MenuAction>();
            foreach (var action in allActions)
            {
                Console.WriteLine(GetMessageByMenuAction(action));
            }
        }

        static MenuAction GetUserMenuAction(string input) =>
            int.TryParse(input, out var actionNumber)
            ? Enum.IsDefined((MenuAction)actionNumber) ? (MenuAction)actionNumber : MenuAction.Exit
            : MenuAction.Exit;

        private static string ExecuteActionOnFile(MenuAction action, string fileName)
        {
            var sourceText = File.ReadAllText(fileName);
            if (string.IsNullOrWhiteSpace(sourceText))
            {
                return EmptySourceError;
            }

            return action switch
            {
                MenuAction.Exit => "Goodbye!",
                MenuAction.FindLargestWord => ExecuteFindLargestWordAction(sourceText),
                MenuAction.ReplaceNumbersWithWords => ExecuteReplaceNumbersWithWordsAction(sourceText, fileName),
                MenuAction.ShowIntonationSentences => ExecuteShowIntonationSentencesAction(sourceText),
                MenuAction.ShowSimpleSentences => ExecuteShowSimpleSentencesAction(sourceText),
                MenuAction.FindWordsWithSameStartAndEnd => ExecuteFindWordsWithSameStartAndEndAction(sourceText),
                _ => string.Empty
            };
        }

        private static string ExecuteFindLargestWordAction(string source)
        {
            var words = GetAllWords(source);

            var maxWord = string.Empty;
            var maxWordCount = 0;
            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                if (word.Length > maxWord.Length)
                {
                    maxWord = word;
                    maxWordCount = 1;
                }
                else if (word == maxWord)
                {
                    maxWordCount++;
                }
            }

            return $"The lergest word is \"{maxWord}\"\n It has {maxWordCount} repetitions";
        }

        private static string ExecuteReplaceNumbersWithWordsAction(string source, string fileName)
        {
            string updatedText = null;
            for(var i = 0; i< 9; i++)
            {
                var replaceWith = GetDigitRepresentation(i);
                updatedText = source.Replace(i.ToString(), replaceWith);
            }

            if(source == updatedText)
            {
                return ThereIsNothingToUpdate;
            }

            File.WriteAllText(fileName, updatedText);
            return SourceIsUpdated;
        }

        private static string ExecuteShowIntonationSentencesAction(string source)
        {
            var sentences = source.Split(SentenceChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var questions = new StringBuilder();
            var exclamations = new StringBuilder();
            foreach (var sentence in sentences)
            {
                var sentenceStart= source.IndexOf(sentence);
                var sentenceEnd = source[sentenceStart + sentence.Length];
                if (sentenceEnd == ExclamationMark)
                {
                    exclamations.AppendLine(sentence);
                }
                else if (sentenceEnd == QuestionMark)
                {
                    questions.AppendLine(sentence);
                }
            }

            return @$"Questins:{Environment.NewLine}{questions}{Environment.NewLine}Exclamations:{Environment.NewLine}{exclamations}";
        }

        private static string ExecuteShowSimpleSentencesAction(string source)
        {
            var sentences = source.Split(SentenceChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var simpleSentences = new StringBuilder();
            foreach (var sentence in sentences)
            {
                if(sentence.IndexOfAny(PunctiationChars) == -1)
                {
                    simpleSentences.AppendLine(sentence);
                }
            }

            return $"Simple sentences:{Environment.NewLine}{simpleSentences}";
        }

        private static string ExecuteFindWordsWithSameStartAndEndAction(string source)
        {
            var words = GetAllWords(source);
            var repeatingSymbolWords = new StringBuilder();
            foreach (var word in words)
            {
                var startingSymbol = word[0];
                if (word.EndsWith(startingSymbol))
                {
                    repeatingSymbolWords.AppendLine(word);
                }
            }

            return $"Repeating symbol words:{Environment.NewLine}{repeatingSymbolWords}";
        }

        private static string[] GetAllWords(string source)
        {
            var wordSeparators = CombineArrays(SentenceChars, PunctiationChars, SpaceChars);
            return source.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        private static string GetDigitRepresentation(int digit) => digit switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            0 => "zero",
            _ => throw new ArgumentException("Not a digit")
        };

        private static string GetMessageByMenuAction(MenuAction action) => action switch
        {
            MenuAction.Exit => $"{(int)MenuAction.Exit} - Exit",
            MenuAction.FindLargestWord => $"{(int)MenuAction.FindLargestWord} - Show the largest word and its repetitions",
            MenuAction.ReplaceNumbersWithWords => $"{(int)MenuAction.ReplaceNumbersWithWords} - Replace numbers with words",
            MenuAction.ShowIntonationSentences => $"{(int)MenuAction.ShowIntonationSentences} - Show intonation sentences",
            MenuAction.ShowSimpleSentences => $"{(int)MenuAction.ShowSimpleSentences} - Show simple sentences",
            MenuAction.FindWordsWithSameStartAndEnd => $"{(int)MenuAction.FindWordsWithSameStartAndEnd} - Show words with same first and last letters",
            _ => string.Empty
        };

        private static bool TryGetFileNameFromArgs(string[] args, out string fileName)
        {
            fileName = null;
            if (args == null || args.Length != 1)
            {
                return false;
            }

            if (File.Exists(args[0]))
            {
                fileName = args[0];
            }

            return fileName != null;
        }

        private static char[] CombineArrays(params char[][] arrays)
        {
            var commonLength = 0;
            foreach (var array in arrays)
            {
                commonLength += array.Length;
            }

            var resultArray = new char[commonLength];
            var indexToInsert = 0;
            foreach (var array in arrays)
            {
                Array.Copy(array, 0, resultArray, indexToInsert, array.Length);
                indexToInsert += array.Length;
            }

            return resultArray;
        }
    }
}