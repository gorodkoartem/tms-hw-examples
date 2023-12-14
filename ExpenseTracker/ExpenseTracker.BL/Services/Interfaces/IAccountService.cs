using ExpenseTracker.BL.Models;

namespace ExpenseTracker.BL.Services.Interfaces;

public interface IAccountService
{
    ServiceDataResponse<Guid> CreateAccount(Account account);
    ServiceDataResponse<IEnumerable<Account>> GetAccounts();
    ServiceDataResponse<Account> GetAccountById(Guid accountId);
    ServiceDataResponse<Account> UpdateAccount(Account account);
    ServiceResponse DeleteAccount(Guid accountId);
}
