const string StartingMessage = "Please enter the month number (1 - 12):";
const string ResultMessage = "Season is identified: ";
const string InvalidMonthNumberError = "Invalid number was entered.";
const string NotNumberError = "You entered not a number.";

Console.WriteLine(StartingMessage);
var userInput = Console.ReadLine();

string userOutput;
if(int.TryParse(userInput, out var month))
{
    var season = GetSeasonByMonth(month);
    userOutput = season == null
        ? InvalidMonthNumberError
        : ResultMessage + season;
}
else
{
    userOutput = NotNumberError;
}

Console.WriteLine(userOutput);

static string GetSeasonByMonth(int month)
{
    const string Winter = "Winter";
    const string Spring = "Spring";
    const string Summer = "Summer";
    const string Autumn = "Autumn";

    const int JanMonth = 1;
    const int FebMonth = 2;
    const int MarchMonth = 3;
    const int AprilMonth = 4;
    const int MayMonth = 5;
    const int JuneMonth = 6;
    const int JulyMonth = 7;
    const int AugustMonth = 8;
    const int SeptMonth = 9;
    const int OctMonth = 10;
    const int NovMonth = 11;
    const int DecMonth = 12;

    string season;
    switch (month)
    {
        case DecMonth:
        case JanMonth:
        case FebMonth:
            season = Winter;
            break;
        case MarchMonth:
        case AprilMonth:
        case MayMonth:
            season = Spring;
            break;
        case JuneMonth:
        case JulyMonth:
        case AugustMonth:
            season = Summer;
            break;
        case SeptMonth:
        case OctMonth:
        case NovMonth:
            season = Autumn;
            break;
        default:
            season = null;
            break;
    }

    return season;
}