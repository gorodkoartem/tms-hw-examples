using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DAL.Models;
public class Expense
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Payment {  get; set; }
    public string? Comment {  get; set; }

    [Required]
    public Category? Category { get; set; }

    [Required]
    public Account? Account { get; set; }
}
