const string StartingMessage = "Please enter a number:";
const string ResultMessage = "The number is ";
const string Even = "even";
const string Odd = "odd";
const string NotNumberError = "You entered not a number.";

Console.WriteLine(StartingMessage);
var userInput = Console.ReadLine();

string userOutput;
if (int.TryParse(userInput, out var number))
{
    userOutput = ResultMessage + (number % 2 == 0 ? Even : Odd);
}
else
{
    userOutput = NotNumberError;
}

Console.WriteLine(userOutput);