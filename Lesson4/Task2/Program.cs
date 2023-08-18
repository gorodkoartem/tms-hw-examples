using Task2;

ConsoleKey controlKey;
do
{
    Console.WriteLine("Enter an expression (12+123):");
    var userInput = Console.ReadLine();
    Console.WriteLine(
        TryGetExpressionDetails(userInput, out var leftNumber, out var rightNumber, out var operation)
        ? $"={CalculateExpression(leftNumber, rightNumber, operation)}"
        : "Invlaid input");

    Console.WriteLine("dfg");
    controlKey = Console.ReadKey().Key;
} while (controlKey != ConsoleKey.Escape);

static double CalculateExpression(int leftNumber, int rightNumber, Operation operation) => operation switch
{
    Operation.Addition => leftNumber + rightNumber,
    Operation.Substraction => leftNumber - rightNumber,
    Operation.Division => CalculateDivision(leftNumber, rightNumber),
    Operation.Multiplication => leftNumber * rightNumber,
    _ => double.NaN
};

static bool TryGetExpressionDetails(string expression, out int leftNumber, out int rightNumber, out Operation operation)
{
    leftNumber = 0;
    rightNumber = 0;
    operation = 0;

    if (string.IsNullOrEmpty(expression))
    {
        return false;
    }

    var operationSymbols = new char[] { '+', '-', '*', '/' };

    var operationIndex = expression.IndexOfAny(operationSymbols);
    if (operationIndex == -1)
    {
        return false;
    }

    var inputs = expression.Split(operationSymbols);
    if (inputs.Length != 2
       || !int.TryParse(inputs[0], out leftNumber)
       || !int.TryParse(inputs[1], out rightNumber))
    {
        return false;
    }

    operation = TryGetOperationBySymbol(expression[operationIndex]);
    return true;
}

static Operation TryGetOperationBySymbol(char symbol) => symbol switch
{
    '+' => Operation.Addition,
    '-' => Operation.Substraction,
    '*' => Operation.Multiplication,
    '/' => Operation.Division,
    _ => Operation.None
};

static double CalculateDivision(int leftNumber, int rigthNumber) => rigthNumber == 0
        ? leftNumber > 0 ? double.PositiveInfinity : double.NegativeInfinity
        : (double)leftNumber / rigthNumber;