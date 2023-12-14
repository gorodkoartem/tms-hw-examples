using ExpenseTracker.BL.Models;

namespace ExpenseTracker.BL.Services.Interfaces;

public interface IExpenseService
{
    ServiceDataResponse<IEnumerable<Expense>> GetExpenses(Category? category, Account? account);
    ServiceDataResponse<Expense> GetExpenseById(Guid id);
    ServiceDataResponse<Guid> CreateExpense(Expense expense);
    ServiceDataResponse<Expense> UpdateExpense(Expense expense);
    ServiceResponse DeleteExpense(Expense expense);
}
