using AutoMapper;
using ExpenseTracker.BL.Models;
using ExpenseTracker.BL.Services.Interfaces;
using ExpenseTracker.DAL;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.BL.Services;

public class AccountService : IAccountService
{
    private readonly ExpenseTrackerDbContext _dbContext;
    private readonly IMapper _mapper;

    public AccountService(ExpenseTrackerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ServiceDataResponse<Account>> CreateAccountAsync(Account account)
    {
        if (account == null)
        {
            return ServiceDataResponse<Account>.Failed("Data cannot be null");
        }

        if (await _dbContext.Accounts.AnyAsync(a => a.Name == account.Name))
        {
            return ServiceDataResponse<Account>.Failed("Account with this name already exists");
        }

        account.Id = Guid.NewGuid();
        var dalAccount = _mapper.Map<DAL.Models.Account>(account);

        _dbContext.Accounts.Add(dalAccount);
        await _dbContext.SaveChangesAsync();

        return ServiceDataResponse<Account>.Succeeded(account);
    }

    public async Task<ServiceResponse> DeleteAccountAsync(Guid accountId)
    {
        var account = await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Id == accountId);
        if (account == null)
        {
            return ServiceResponse.Failed("Account doesn't exist");
        }

        _dbContext.Accounts.Remove(account);
        await _dbContext.SaveChangesAsync();
        return ServiceResponse.Succeeded();
    }

    public async Task<ServiceDataResponse<Account>> GetAccountByIdAsync(Guid accountId)
    {
        var account = await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Id == accountId);
        if (account == null)
        {
            return ServiceDataResponse<Account>.Failed("Account doesn't exist");
        }

        return ServiceDataResponse<Account>.Succeeded(_mapper.Map<Account>(account));
    }

    public async Task<ServiceDataResponse<IEnumerable<Account>>> GetAccountsAsync()
    {
        var accounts = await _dbContext.Accounts.ToListAsync();
        return ServiceDataResponse<IEnumerable<Account>>.Succeeded(_mapper.Map<IEnumerable<Account>>(accounts));
    }

    public async Task<ServiceDataResponse<Account>> UpdateAccountAsync(Account account)
    {
        if (account == null)
        {
            return ServiceDataResponse<Account>.Failed("Data cannot be null");
        }

        var dbCategory = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == account.Id);
        if (dbCategory == null)
        {
            return ServiceDataResponse<Account>.Failed("Account doesn't exist");
        }

        if (await _dbContext.Accounts.AnyAsync(a => a.Name == account.Name))
        {
            return ServiceDataResponse<Account>.Failed("Account with this name already exists");
        }

        dbCategory.Name = account.Name;
        await _dbContext.SaveChangesAsync();

        return ServiceDataResponse<Account>.Succeeded(account);
    }
}
