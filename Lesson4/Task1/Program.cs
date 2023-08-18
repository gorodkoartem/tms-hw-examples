var arrayForTests = new int[] { 0, 1, 2, 3, 423, 5, 6, 7, 123 };
var expectedMax = arrayForTests.Max();
if(FindMaxValue(arrayForTests) == expectedMax)
{
    Console.WriteLine($"{nameof(FindMaxValue)} method works correctly");
}
//----------------------

var zubArrayForTests = new int[][] {
    new int[] { 1, 2, 3 },
    new int[] { 1, 2, 3, 4, 5 },
    new int[] { 1, 2 },
    new int[] { 1, -1 }
};
var expectedAvg = 2d;
if (CalculteAverageValue(zubArrayForTests) == expectedAvg)
{
    Console.WriteLine($"{nameof(CalculteAverageValue)} method works correctly");
}
//----------------------

Console.WriteLine($"Fibonacci sequence: {string.Join(' ', GenerateFibonacciSequence(10))}");
//----------------------

static int FindMaxValue(int[] array)
{
    if (array == null || array.Length == 0)
    {
        throw new ArgumentException($"Parameter \"{nameof(array)}\" is null or empty.");
    }

    var max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        max = array[i] > max ? array[i] : max;
    }

    return max;
}

static double CalculteAverageValue(int[][] array)
{
    if (array == null || array.Length == 0)
    {
        throw new ArgumentException($"Parameter \"{nameof(array)}\" is null or empty.");
    }

    var sum = 0d;
    var totalLength = 0;
    foreach (var subArray in array)
    {
        if (subArray == null)
        {
            continue;
        }

        totalLength += subArray.Length;
        foreach (var item in subArray)
        {
            sum+= item;
        }
    }

    return sum/totalLength;
}

static int[] GenerateFibonacciSequence(int n)
{
    const int fibonacciSequenceFirst = 0;
    const int fibonacciSequenceSecond = 1;

    if (n < 0)
    {
        throw new ArgumentException($"Parameter \"{nameof(n)}\" must be 0 or greater.");
    }

    if (n == 0)
    {
        return Array.Empty<int>();
    }

    if (n == 1)
    {
        return new int[] { fibonacciSequenceFirst };
    }

    var fibonacciSequence = new int[n];
    fibonacciSequence[0] = fibonacciSequenceFirst;
    fibonacciSequence[1] = fibonacciSequenceSecond;
    for (var i = 2; i < n; i++)
    {
        fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
    }

    return fibonacciSequence;
}