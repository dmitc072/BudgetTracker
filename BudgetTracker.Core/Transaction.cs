namespace BudgetTracker.Core.Models;

public enum TransactionType
{
    Income,
    Expense
}

public record Transaction(
    decimal Amount,
    string Description,
    string Category,
    DateTime Date,
    TransactionType Type
);
