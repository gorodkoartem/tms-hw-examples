namespace ExpenseTracker.DAL.Models;
public class Account
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Expense>? Expenses { get; set; }
}
