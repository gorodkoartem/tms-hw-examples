using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaymentToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Payment",
                table: "Expenses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Expenses");
        }
    }
}
