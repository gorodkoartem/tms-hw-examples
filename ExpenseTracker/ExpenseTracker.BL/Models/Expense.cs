namespace ExpenseTracker.BL.Models;
public class Expense
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Payment { get; set; }
    public string? Comment { get; set; }
    public Guid AccountId { get; set; }
    public Guid CategoryId { get; set; }
}
