namespace ExpenseTracker.BL.Models;

public class ServiceResponse
{
    public string? ErrorMessage { get; set; }
    public bool IsSucceeded { get; set; }


    public static ServiceResponse Failed(string errorMessage)
    {
        return new ServiceResponse
        {
            IsSucceeded = false,
            ErrorMessage = errorMessage
        };
    }

    public static ServiceResponse Succeeded()
    {
        return new ServiceResponse
        {
            IsSucceeded = true,
        };
    }
}
