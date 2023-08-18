const string StartingMessage = "Please enter the temperature (temperature must be an integer number):";
const string ResultMessage = "Weather type is identified: ";
const string NotNumberError = "You entered not a number.";

Console.WriteLine(StartingMessage);
var userInput = Console.ReadLine();

string userOutput = int.TryParse(userInput, out var month)
    ? ResultMessage + GetWeatherTypeByTemperature(month)
    : NotNumberError;

Console.WriteLine(userOutput);

static string GetWeatherTypeByTemperature(int temperature)
{
    const string Warm = "Тепло";
    const string Normal = "Нормально";
    const string Cold = "Холодно";

    const int WarmMinTemperature = -5;
    const int NormalMinTemperature = -20;

    string weatherType;
    if(temperature > WarmMinTemperature)
    {
        weatherType = Warm;
    }
    else if(temperature > NormalMinTemperature)
    {
        weatherType= Normal;
    }
    else
    {
        weatherType = Cold;
    }

    return weatherType;
}