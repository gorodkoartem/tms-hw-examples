using ExpenseTracker.BL.Models;

namespace ExpenseTracker.BL.Services.Interfaces;

public interface IAccountService
{
    Task<ServiceDataResponse<Account>> CreateAccountAsync(Account account);
    Task<ServiceDataResponse<IEnumerable<Account>>> GetAccountsAsync();
    Task<ServiceDataResponse<Account>> GetAccountByIdAsync(Guid accountId);
    Task<ServiceDataResponse<Account>> UpdateAccountAsync(Account account);
    Task<ServiceResponse> DeleteAccountAsync(Guid accountId);
}
