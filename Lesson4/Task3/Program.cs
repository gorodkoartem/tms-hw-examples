var initialArray = new int[] { 0, 1, 2, 3, 423, -5, 6, 7, 123 };

var arrayToSort = (int[])initialArray.Clone();
BubbleSort(arrayToSort);

var expectedArray = (int[])initialArray.Clone();
Array.Sort(expectedArray);

if (string.Join(' ', arrayToSort) == string.Join(' ', expectedArray))
{
    Console.WriteLine("Algorithm works");
}

static void BubbleSort(int[] array)
{
    if (array == null)
    {
        throw new ArgumentNullException(nameof(array));
    }

    for (var i = 0; i < array.Length; i++)
    {
        for(var j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                var temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
    }
}