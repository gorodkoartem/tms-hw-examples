namespace ExpenseTracker.BL.Models;

public class ServiceDataResponse<T> : ServiceResponse
{
    public T? Data { get; set; }

    public static new ServiceDataResponse<T> Failed(string message)
    {
        return new ServiceDataResponse<T>
        {
            IsSucceeded = false,
            ErrorMessage = message
        };
    }

    public static ServiceDataResponse<T> Succeeded(T data)
    {
        return new ServiceDataResponse<T>
        {
            IsSucceeded = true,
            Data = data
        };
    }
}
