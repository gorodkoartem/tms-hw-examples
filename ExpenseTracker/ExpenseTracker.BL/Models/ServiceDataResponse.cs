namespace ExpenseTracker.BL.Models;

public class ServiceDataResponse<T> : ServiceResponse
{
    public T? Data { get; set; }

    public static ServiceDataResponse<T> Failed(string message)
    {
        return new ServiceDataResponse<T>
        {
            Succeeded = false,
            ErrorMessage = message
        };
    }
}
